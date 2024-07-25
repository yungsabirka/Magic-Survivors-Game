using System.Collections;
using UnityEngine;

public class WizardAttacker : EnemyAttacker
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private int _attackDelay;

    private CharacterCenterPosition _targetCenter;

    public override void Attack()
    {
        if(_target != null && _targetCenter == null)
            _targetCenter = _target.GetComponentInChildren<CharacterCenterPosition>();

        var targetCenterPosition = _targetCenter.CenterPosition;
        var direction = targetCenterPosition - transform.position;
        var projectile = Instantiate(_projectile, transform.position, _projectile.transform.rotation);
        projectile.transform.right = direction;
        projectile.GetComponent<EnemyProjectileAttacker>().SetDamage(_damage);

        _animator.Animator.SetBool(_animator.IsAttackId, false);
        _isCanAttack = false;
        
        StartCoroutine(WaitForAttack());
    }

    private IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(_attackDelay);
        _isCanAttack = true;
        StopAllCoroutines();
    }
}
