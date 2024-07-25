using System;
using System.Collections.Generic;
using UnityEngine;

public class TridentsInteractor : Interactor
{
    public event Action<float> DamageChanged;
    public event Action<float> AngularSpeedChanged;

    private TridentsRepository _repository;
    private int _filledCellsAmount;

    public IReadOnlyCollection<Transform> TridentCells => _repository.TridentCells;
    public bool AllTridentCellsFilled => _filledCellsAmount >= _repository.MaxTridentAmount;
    public int FilledCellsAmount => _filledCellsAmount;
    public float AngularSpeed => _repository.AngularSpeed;
    public float Damage => _repository.Damage;
    public float StandartDamage => _repository.StandartDamage;
    public float StandartAngularSpeed => _repository.StandartAngularSpeed;

    public override void OnCreate()
    {
        base.Initialize();
        _repository = Game.GetRepository<TridentsRepository>();
    }

    public void ChangeDamage(float damage)
    {
        _repository.Damage = damage;
        DamageChanged?.Invoke(damage);
    }

    public void ChangeAngularSpeed(float angularSpeed)
    {
        _repository.AngularSpeed = angularSpeed;
        AngularSpeedChanged?.Invoke(angularSpeed);
    }

    public void AddTridentCell(Transform cell)
    {
        if (_repository.TridentCells.Count >= _repository.MaxTridentAmount)
            return;
        
        _repository.TridentCells.Add(cell);
    }

    public Transform GetEmptyCell()
    {
        _filledCellsAmount++;
        return _repository.TridentCells[_filledCellsAmount - 1];
    }
}

