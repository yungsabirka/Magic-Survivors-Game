using UnityEngine;

public class MagixBookProjectileAttacker : MonoBehaviour
{
    private const int EnemyLayer = 1 << 6;

    private MagixBookInteractor _interactor;
    private float _damage;

    private void Start()
    {
        _interactor = Game.GetInteractor<MagixBookInteractor>();
        _interactor.StatsChanged += SetDamage;
        SetDamage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (EnemyLayer >> collision.gameObject.layer != 1)
            return;

        var enemyHealth = collision.GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage((int)_damage);
        Destroy(gameObject);
    }

    public void SetDamage() => _damage = _interactor.CurrentStats.Damage;
}

