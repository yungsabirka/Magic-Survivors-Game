using System;
using System.Collections.Generic;
using UnityEngine;

public class MagixBookInteractor : Interactor
{
    public event Action StatsChanged;

    private MagixBookRepository _repository;

    public List<Transform> MovingPoints => _repository.MovingPoints;
    public MagixBookStats StandartStats => _repository.StandartStats;
    public MagixBookStats CurrentStats => _repository.CurrentStats;

    public override void Initialize()
    {
        base.Initialize();
        _repository = Game.GetRepository<MagixBookRepository>();    
    }

    public void AddPoint(Transform point) => MovingPoints.Add(point);

    public void SetStats(MagixBookStats stats)
    {
        _repository.CurrentStats = stats;
        StatsChanged?.Invoke();
    }
}

