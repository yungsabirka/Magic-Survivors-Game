using System;
using System.Collections.Generic;

public class GameplaySceneConfig : SceneConfig
{
    public const string Name = "Gameplay";

    public override string SceneName => Name;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<PlayerLevelInteractor>(interactorsMap);
        CreateInteractor<MoneyInteractor>(interactorsMap);
        CreateInteractor<PlayerInfoInteractor>(interactorsMap);
        CreateInteractor<TridentsInteractor>(interactorsMap);
        CreateInteractor<MagixBookInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<PlayerLevelRepository>(repositoriesMap);
        CreateRepository<MoneyRepository>(repositoriesMap);
        CreateRepository<PlayerInfoRepository>(repositoriesMap);
        CreateRepository<TridentsRepository>(repositoriesMap);
        CreateRepository<MagixBookRepository>(repositoriesMap);

        return repositoriesMap;
    }
}

