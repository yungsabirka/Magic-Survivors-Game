using UnityEngine;
using static UnityEditor.Progress;

public class ItemsPicker : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private PlayerHealth _health;

    private const int ItemLayer = 1 << 8;
    private bool _isDied;

    private void OnEnable()
    {
        _health.Died += SetDeath;
    }

    private void OnDisable()
    {
        _health.Died -= SetDeath;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ItemLayer >> collision.gameObject.layer != 1 || _isDied)
            return;

        var mover = collision.GetComponent<ItemMover>();
        if (mover.Target != null)
            return;

        mover.SetTarget(transform);
        mover.Arrived += PickUp;
    }

    private void PickUp(Item item)
    {
        switch (item.Type)
        {
            case ItemType.MoneyCoin:
                Game.GetInteractor<MoneyInteractor>().AddCoins(item.Value);
                break;
            case ItemType.LevelCoin:
                Game.GetInteractor<PlayerLevelInteractor>().AddLevelValue(item.Value);
                break;
        }
        item.GetComponent<ItemMover>().Arrived -= PickUp;
        Destroy(item.gameObject);
    }

    private void SetDeath() => _isDied = true;
}