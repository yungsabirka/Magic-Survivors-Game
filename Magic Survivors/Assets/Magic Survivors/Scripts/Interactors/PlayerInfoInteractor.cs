using System;
using UnityEngine;

public class PlayerInfoInteractor : Interactor
{
    public event Action StatsChanged;
    public event Action HealthChanged;
    public event Action Died;

    private PlayerInfoRepository _repository;

    public CharacterStats CurrentStats => _repository.CurrentStats;
    public CharacterStats StandartStats => _repository.StandartStats;
    public Vector3 Position => _repository.Position;
    public float Health => _repository.Health;

    public override void Initialize()
    {
        base.Initialize();
        _repository = Game.GetRepository<PlayerInfoRepository>();
    }

    public void SetPosition(Vector3 position)
    {
        _repository.Position = position;
    }

    public void SetHealth(float health)
    {
        _repository.Health = health;
        HealthChanged?.Invoke();

        if(health <= 0)
            Died?.Invoke();
    }

    public void SetStats(CharacterStats stats)
    {
        _repository.CurrentStats = stats;
        StatsChanged?.Invoke();
    }
}

