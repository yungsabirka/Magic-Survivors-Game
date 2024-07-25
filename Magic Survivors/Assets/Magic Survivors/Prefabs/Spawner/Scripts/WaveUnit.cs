using System;
using UnityEngine;

[Serializable]
public struct WaveUnit
{
    public GameObject Enemy;
    public int Amount;
    public int SpawnDelayInSeconds;
    public int TimeBeforeSpawnInSeconds;
}

