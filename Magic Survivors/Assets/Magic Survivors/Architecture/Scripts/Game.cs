using System;
using System.Collections;

public static class Game
{
    public static event Action OnGameInitialized;

    public static SceneManagerBase SceneManager { get; private set; }
    public static PauseHandler PauseHandler { get; private set; }

    public static void Run()
    {
        SceneManager = new GameSceneManagerBase();
        PauseHandler = new PauseHandler();
        Coroutines.StartRoutine(InitializeGameRoutine());
    }

    private static IEnumerator InitializeGameRoutine()
    {
        SceneManager.InitializeSceneMap();
        yield return SceneManager.LoadCurrentSceneAsync();

        OnGameInitialized?.Invoke();
    }

    public static T GetRepository<T>() where T : Repository
        => SceneManager.GetRepository<T>();

    public static T GetInteractor<T>() where T : Interactor
        => SceneManager.GetInteractor<T>();
}