using UnityEngine;

[RequireComponent (typeof(EnemyHealth))]
public class EnemyCoinSpawner : MonoBehaviour, IInitializable
{
    [SerializeField] private Transform _coinsBuffer;
    [SerializeField] private GameObject _levelCoin;
    [SerializeField] private GameObject _moneyCoin;
    [SerializeField] private int _levelCoinAmount;
    [SerializeField] private int _moneyCoinAmount;
    [SerializeField] private float _range;

    private EnemyHealth _health;

    private void Awake()
    {
        _health = GetComponent<EnemyHealth>();
    }

    public void Initialize()
    {
        InstantiateCoins();
        _health.Died += SpawnCoins;
    }

    private void SpawnCoins()
    {
        for (int i = 0; i < _levelCoinAmount + _moneyCoinAmount; i++)
        {
            Transform coin = _coinsBuffer.GetChild(0) ?? throw new System.Exception("Can not get coin");

            var direction = Random.Range(0, 2) == 0 ? Vector3.right : Vector3.left;
            var target = transform.position + (_range * Random.Range(0.1f, 1f) * direction);
            coin.gameObject.SetActive(true);
            coin.parent = null;
            coin.gameObject
                .AddComponent<MovingAlongCurve>()
                .Move(transform.position, target, Vector3.Lerp(transform.position, target, 0.5f) + new Vector3(0, 2, 0), 1)
                .RemoveWhenFinished();
        }
        _health.Died -= SpawnCoins;
    }

    private void InstantiateCoins()
    {
        for (int i = 0; i < _levelCoinAmount; i++)
        {
            var coin = Instantiate(_levelCoin, _coinsBuffer);
            coin.SetActive(false);
        }
        for (int i = 0; i < _moneyCoinAmount; i++)
        {
            var coin = Instantiate(_moneyCoin, _coinsBuffer);
            coin.SetActive(false);
        }
    }
}
