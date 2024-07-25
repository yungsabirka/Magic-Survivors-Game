using System.Collections.Generic;
using UnityEngine;

public class TridentAttacker : MonoBehaviour, IAttacker
{
    private Collider2D _attackField;
    private TridentsInteractor _interactor;
    private int _enemyLayer = 1 << 6;
    private float _damage;
    private ContactFilter2D _contactFilter;

    private void Start()
    {
        _attackField = GetComponent<Collider2D>();
        _interactor = Game.GetInteractor<TridentsInteractor>();
        SetDamage(_interactor.Damage);
        _interactor.DamageChanged += SetDamage;

        _contactFilter = new();
        _contactFilter.SetLayerMask(_enemyLayer);
        _contactFilter.useTriggers = true;
    }

    private void OnDisable()
    {
        _interactor.DamageChanged -= SetDamage;
    }

    private void SetDamage(float damage) => _damage = damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_enemyLayer >> collision.gameObject.layer != 1)
            return;

        var enemyHealth = collision.GetComponent<EnemyHealth>();
        enemyHealth.TakeDamage((int)_damage);
    }

    public void Attack()
    {
        if (_attackField.IsTouchingLayers(_enemyLayer))
        {
            List<Collider2D> attackedEnemies = new();

            _attackField.OverlapCollider(_contactFilter, attackedEnemies);

            foreach (var target in attackedEnemies)
            {
                var enemy = target.GetComponent<EnemyHealth>();
                enemy.TakeDamage((int)_damage);
            }
        }
    }
}

