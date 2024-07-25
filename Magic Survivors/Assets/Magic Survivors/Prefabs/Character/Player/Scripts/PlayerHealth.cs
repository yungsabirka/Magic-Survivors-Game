using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator))]
public class PlayerHealth : MonoBehaviour, IDamagable, IMortal, IInitializable
{
    public Action<float, float> HealthChanged;
    public Action Died;

    private PlayerAnimator _animator;
    private PlayerInfoInteractor _interactor;
    private float _health;
    private float _maxHealth;
    private float _armorValue;
    private bool _isDied;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
    }
    public void Initialize()
    {
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
        _interactor.StatsChanged += SetMaxHealth;
        _interactor.StatsChanged += SetArmor;
        _interactor.HealthChanged += SetHealth;
        SetMaxHealth();
        SetHealth();
        SetArmor();
    }

    private void OnDisable()
    {
        if(_interactor == null)
            return;
        
        _interactor.StatsChanged -= SetMaxHealth;
        _interactor.HealthChanged -= SetHealth;
    }

    private void SetMaxHealth()
    {
        _maxHealth = _interactor.CurrentStats.MaxHealth;
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    private void SetHealth()
    {
        _health = _interactor.Health;
        HealthChanged?.Invoke(_health, _maxHealth);
    }

    private void SetArmor() => _armorValue = _interactor.CurrentStats.Armor;

    public void TakeDamage(int damage)
    {
        if (_isDied)
            return;

        var armoredDamage = damage - _armorValue;

        if (armoredDamage < 0)
            armoredDamage = 0;

        _health -= armoredDamage;

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }
        _interactor.SetHealth(_health);
    }

    public void Heal(float percentValue)
    {
        if (_isDied)
            return;

        _health += (percentValue * _health);

        if (_health > _maxHealth)
            _health = _maxHealth;

        _interactor.SetHealth(_health);
    }

    private void Die()
    {
        _isDied = true;
        _animator.Animator.SetTrigger(_animator.IsDiedId);
        Died.Invoke();
    }
}

