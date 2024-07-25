using System.Collections;
using UnityEngine;

public class BanditAttacker : EnemyAttacker
{
    [SerializeField] private int _attackDelay;

    public override void Attack()
    {
        if (_target == null)
            return;
        
        if (_attackField.IsTouching(_target))
        {
            var playerHealth = _target.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(_damage);
        }
        _animator.Animator.SetBool(_animator.IsAttackId, false);
        StartCoroutine(WaitForAttack());    
    }

    private IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(_attackDelay);
        _isCanAttack = true;
    }
}
