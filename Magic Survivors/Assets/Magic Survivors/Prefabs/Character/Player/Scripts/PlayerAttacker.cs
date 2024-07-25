using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerHealth))]
public class PlayerAttacker : MonoBehaviour, IAttacker, IInitializable
{
    [SerializeField] private Collider2D _attackField;
    [SerializeField] private InputController _inputController;

    private const int EnemyLayer = 1 << 6;

    private PlayerAnimator _animator;
    private PlayerHealth _health;
    private float _damage;
    private bool _isDied;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _health = GetComponent<PlayerHealth>();
    }

    public void Initialize()
    {
        _inputController.Attacked += AnimateAttack;
        Game.GetInteractor<PlayerInfoInteractor>().StatsChanged += SetDamage;
        _health.Died += SetDeath;
        SetDamage();
    }

    private void OnDisable()
    {
        _inputController.Attacked -= AnimateAttack;
        _health.Died -= SetDeath;
        Game.GetInteractor<PlayerInfoInteractor>().StatsChanged -= SetDamage;
    }

    private void SetDamage()
        => _damage = Game.GetInteractor<PlayerInfoInteractor>().CurrentStats.WeaponDamage;

    private void AnimateAttack()
    {
        if (_animator == null || _animator.Animator.GetBool(_animator.IsAttackId) || _isDied)
            return;

        _animator.Animator.SetBool(_animator.IsAttackId, true);
    }

    public void Attack()
    {
        if (_attackField.IsTouchingLayers(EnemyLayer))
        {
            List<Collider2D> attackedEnemies = new();
            ContactFilter2D contactFilter = new();
            contactFilter.SetLayerMask(EnemyLayer);
            contactFilter.useTriggers = true;

            _attackField.OverlapCollider(contactFilter, attackedEnemies);

            foreach (var target in attackedEnemies)
            {
                var enemy = target.GetComponent<EnemyHealth>();
                enemy.TakeDamage((int)_damage);
            }
        }
        _animator.Animator.SetBool(_animator.IsAttackId, false);
    }

    private void SetDeath() => _isDied = true;
}

