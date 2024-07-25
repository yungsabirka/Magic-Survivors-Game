using System.Collections;
using UnityEngine;

public class BureaSlimeAttacker : EnemyAttacker
{
    [SerializeField] private float _interpolateDistanceValue;
    [SerializeField] private float _distanceBehindTarget;
    [SerializeField] private int _attackDelay;

    private bool _isCanHurt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TargetLayer >> collision.gameObject.layer == 1)
        {
            var playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(_damage);
            StartCoroutine(WaitForAttack());
        }
    }


    public override void Attack()
    {
        var targetCenterPosition = _target.GetComponentInChildren<CharacterCenterPosition>().CenterPosition;
        var direction = (targetCenterPosition - transform.position).normalized;

        var startPosition = transform.position;
        var targetPoint = targetCenterPosition + _distanceBehindTarget * direction;

        StartCoroutine(StartAttack(startPosition, targetPoint));
    }

    private IEnumerator StartAttack(Vector3 startPosition, Vector3 targetPoint)
    {
        _animator.Animator.SetBool(_animator.IsAttackId, false);
        var progressPoint = startPosition;
        while (Vector3.Distance(progressPoint, targetPoint) >= 0.05)
        {
            progressPoint = Vector3.Lerp(progressPoint, targetPoint, _interpolateDistanceValue);
            transform.position = progressPoint;
            yield return null;
        }
        StartCoroutine(WaitForAttack());
    }

    private IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(_attackDelay);
        _isCanAttack = true;
        StopAllCoroutines();
    }
}
