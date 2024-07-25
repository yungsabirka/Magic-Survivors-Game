using System;
using System.Collections.Generic;

public class RepositoriesBase
{
    private Dictionary<Type, Repository> _repositoriesMap;
    private SceneConfig _sceneConfig;

    public RepositoriesBase(SceneConfig sceneConfig)
    {
        _repositoriesMap = new Dictionary<Type, Repository>();
        _sceneConfig = sceneConfig;
    }

    public void CreateAllRepositories()
    {
        _repositoriesMap =  _sceneConfig.CreateAllRepositories();
    }

    public void SendOnCreateToAllRepositories()
    {
        foreach (var repository in _repositoriesMap.Values)
            repository.OnCreate();
    }

    public void InitializeAllRepositories()
    {
        foreach (var interactor in _repositoriesMap.Values)
            interactor.Initialize();
    }
    public void SendOnStartToAllRepositories()
    {
        foreach (var interactor in _repositoriesMap.Values)
            interactor.OnStart();
    }

    public T GetRepository<T>() where T : Repository
        => (T)_repositoriesMap[typeof(T)];
}

