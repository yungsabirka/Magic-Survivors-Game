using System.Collections.Generic;
using UnityEngine;

public class MagixBookPointsInitializer : MonoBehaviour, IInitializable
{
    [SerializeField] private List<Transform> _points;

    private void Start()
    {
        Game.OnGameInitialized += Initialize;
    }

    public void Initialize()
    {
        var interactor = Game.GetInteractor<MagixBookInteractor>();

        foreach (var point in _points)
            interactor.AddPoint(point);

        Game.OnGameInitialized -= Initialize;
    }
}


