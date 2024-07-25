using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IInitializable
{
    [SerializeField] private List<EnemyWave> _waves;
    [SerializeField] private WaveView _waveView;

    private List<GameObject> _enemies;
    private Camera _camera;
    private PlayerInfoInteractor _interactor;

    public IReadOnlyList<GameObject> Enemies => _enemies;

    public void Initialize()
    {
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
        _interactor.Died += StopAllCoroutines;
        _camera = Camera.main;
        _enemies = new List<GameObject>();
        StartCoroutine(nameof(StartSpawnWaves));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        _interactor.Died -= StopAllCoroutines;
    }

    private IEnumerator StartSpawnWaves()
    {
        foreach (var wave in _waves)
        {
            _waveView.SetWave(wave.name);
            wave.SetIsAllSpawned(false);
            foreach (var waveUnit in wave.WaveUnits)
                StartCoroutine(SpawnWave(wave, waveUnit));

            yield return new WaitWhile(() => (_enemies.Count != 0 || wave.IsAllSpawned == false));
        }
        yield break;
    }

    private IEnumerator SpawnWave(EnemyWave wave, WaveUnit waveUnit)
    {
        yield return new WaitForSeconds(waveUnit.TimeBeforeSpawnInSeconds);
        for (int i = 0; i < waveUnit.Amount; i++)
        {
            CreateEnemy(waveUnit.Enemy);
            yield return new WaitForSeconds(waveUnit.SpawnDelayInSeconds);
        }
        wave.SetIsAllSpawned(true);
    }

    private void CreateEnemy(GameObject enemy)
    {
        Vector3 enemyPosition = RandomEnemyPosition();
        var clone = Instantiate(enemy, enemyPosition, enemy.transform.rotation);
        _enemies.Add(clone);

        var enemyHealth = clone.GetComponent<EnemyHealth>();
        enemyHealth.Dying += OnDying;

        var initializer = clone.GetComponent<Initializer>();
        initializer.Initialize();
    }

    private Vector3 RandomEnemyPosition()
    {
        return _camera.ViewportToWorldPoint(new Vector3(
                Random.Range(1f, 1.5f) * (Random.Range(0, 2) == 0 ? -1 : 1),
                Random.Range(1f, 1.5f) * (Random.Range(0, 2) == 0 ? -1 : 1),
                -_camera.transform.position.z));
    }

    private void OnDying(GameObject enemy)
    {
        _enemies.Remove(enemy);
        var health = enemy.GetComponent<EnemyHealth>();
        health.Dying -= OnDying;
    }
}
