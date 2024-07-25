using System;
using System.Collections.Generic;

public class ShopSceneConfig : SceneConfig
{
    public const string Name = "Shop";

    public override string SceneName => Name;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<MoneyInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<MoneyRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
