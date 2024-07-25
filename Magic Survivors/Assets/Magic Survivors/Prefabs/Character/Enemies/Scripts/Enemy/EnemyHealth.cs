using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public class EnemyHealth : MonoBehaviour, IDamagable, IMortal, IInitializable
{
    [SerializeField] private int _health;

    public event Action Died;
    public event Action<GameObject> Dying;
    public Action<int, int> HealthChanged;

    private EnemyAnimator _animator;
    private int _maxHealth;
    private bool _isDied;

    public bool IsDied => _isDied;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimator>();
    }

    public void Initialize()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        if (_isDied)
            return;

        _health -= damage;
        HealthChanged.Invoke(_health, _maxHealth);

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }
        else
            _animator.Animator.SetTrigger(_animator.IsHurtId);        
    }

    private void Die()
    {
        _isDied = true;
        Died?.Invoke();
        Dying?.Invoke(gameObject);
        _animator.Animator.SetTrigger(_animator.IsDiedId);
        StartCoroutine(nameof(WaitForDestroy));
    }

    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

