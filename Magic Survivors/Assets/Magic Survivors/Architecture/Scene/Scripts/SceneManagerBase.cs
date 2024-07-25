using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneManagerBase
{
    public event Action<Scene> OnSceneLoaded;

    protected Dictionary<string, SceneConfig> _sceneConfigMap;

    public Scene Scene { get; private set; }
    public bool IsLoading { get; private set; }

    public SceneManagerBase()
    {
        _sceneConfigMap = new Dictionary<string, SceneConfig>();
    }

    public abstract void InitializeSceneMap();

    public Coroutine LoadCurrentSceneAsync()
    {
        if (IsLoading)
            throw new Exception("Scene is loading now");

        var sceneName = SceneManager.GetActiveScene().name;
        var config = _sceneConfigMap[sceneName];

        return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
    }

    public Coroutine LoadNewSceneAsync(string sceneName)
    {
        if (IsLoading)
            throw new Exception("Scene is loading now");

        var config = _sceneConfigMap[sceneName];

        return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
    }

    private IEnumerator LoadCurrentSceneRoutine(SceneConfig config)
    {
        IsLoading = true;

        yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));

        IsLoading = false;
        OnSceneLoaded?.Invoke(Scene);
    }

    private IEnumerator LoadNewSceneRoutine(SceneConfig config)
    {
        IsLoading = true;

        yield return Coroutines.StartRoutine(LoadSceneRoutine(config));
        yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));

        IsLoading = false;
        OnSceneLoaded?.Invoke(Scene);
    }

    private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
    {
        var async = SceneManager.LoadSceneAsync(sceneConfig.SceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
            yield return null;

        async.allowSceneActivation = true;
    }

    private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
    {
        Scene = new Scene(sceneConfig);
        yield return Scene.InitializeAsync();
    }

    public T GetRepository<T>() where T : Repository
        => Scene.GetRepository<T>();
    
    public T GetInteractor<T>() where T : Interactor 
        => Scene.GetInteractor<T>();
}

