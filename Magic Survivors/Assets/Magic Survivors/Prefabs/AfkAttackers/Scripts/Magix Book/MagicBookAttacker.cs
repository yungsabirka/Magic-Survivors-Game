using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBookAttacker : MonoBehaviour, IAttacker
{
    [SerializeField] private GameObject _projectile;

    private const int EnemyLayer = 1 << 6;

    private CircleCollider2D _attackField;
    private MagixBookInteractor _interactor;
    private ContactFilter2D _contactFilter;
    private float _attackDelayInSeconds;

    private void Start()
    {
        _attackField = GetComponent<CircleCollider2D>();
        _interactor = Game.GetInteractor<MagixBookInteractor>();
        _interactor.StatsChanged += SetAttackDelayInSeconds;
        _interactor.StatsChanged += SetAttackRadius;
        SetAttackDelayInSeconds();
        SetAttackRadius();
        _contactFilter = new();
        _contactFilter.SetLayerMask(EnemyLayer);
        _contactFilter.useTriggers = true;
        StartCoroutine(AttackWithDelay());
    } 

    private void OnDisable()
    {
        StopCoroutine(AttackWithDelay());
    }

    private IEnumerator AttackWithDelay()
    {
        while (true)
        {
            if (_attackField.IsTouchingLayers(EnemyLayer))
            {
                Attack();
            }
            yield return new WaitForSeconds(_attackDelayInSeconds);
        }
    }

    public void Attack()
    {
        List<Collider2D> attackedEnemies = new();

        _attackField.OverlapCollider(_contactFilter, attackedEnemies);
        if (attackedEnemies.Count == 0)
            return;

        var randomEnemy = Random.Range(0, attackedEnemies.Count);

        var enemy = attackedEnemies[randomEnemy];
        var enemyCenterPosition = enemy.GetComponentInChildren<CharacterCenterPosition>().CenterPosition;
        
        var direction = enemyCenterPosition - transform.position;
        var projectile = Instantiate(_projectile, transform.position, _projectile.transform.rotation);
        projectile.transform.right = direction;
    }

    public void SetAttackRadius() => _attackField.radius = _interactor.CurrentStats.AttackRadius;

    public void SetAttackDelayInSeconds() => _attackDelayInSeconds = _interactor.CurrentStats.AttackDelayInSeconds;
}

