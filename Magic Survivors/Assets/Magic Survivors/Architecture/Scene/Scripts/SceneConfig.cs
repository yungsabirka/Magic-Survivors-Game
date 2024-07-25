using System;
using System.Collections.Generic;

public abstract class SceneConfig
{
    public abstract Dictionary<Type, Repository> CreateAllRepositories();
    public abstract Dictionary<Type, Interactor> CreateAllInteractors();

    public abstract string SceneName { get; }

    public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorsMap) where T : Interactor, new()
        => interactorsMap.Add(typeof(T), new T());

    public void CreateRepository<T>(Dictionary<Type, Repository> repositoriesMap) where T : Repository, new()
        => repositoriesMap.Add(typeof(T), new T());
}

