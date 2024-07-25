using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWave")]
public class EnemyWave : ScriptableObject
{
    [SerializeField] private List<WaveUnit> _waveUnits;

    private bool _isAllSpawned = false;

    public IReadOnlyList<WaveUnit> WaveUnits => _waveUnits;
    public bool IsAllSpawned => _isAllSpawned;

    public bool SetIsAllSpawned(bool isAllSpawned) => _isAllSpawned = isAllSpawned;
}
