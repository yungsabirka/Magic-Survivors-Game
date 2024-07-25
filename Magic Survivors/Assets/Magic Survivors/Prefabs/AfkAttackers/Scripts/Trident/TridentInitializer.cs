using System.Collections.Generic;
using UnityEngine;

public class TridentInitializer : MonoBehaviour, IInitializable
{
    [SerializeField] private List<Transform> _tridentCells;
    [SerializeField] private Transform _rotationCenter;

    private void Start()
    {
        Game.OnGameInitialized += Initialize;
    }

    public void Initialize()
    {
        var interactor = Game.GetInteractor<TridentsInteractor>();

        foreach (var cell in _tridentCells)       
            interactor.AddTridentCell(cell);

        Game.OnGameInitialized -= Initialize;
    }

}
