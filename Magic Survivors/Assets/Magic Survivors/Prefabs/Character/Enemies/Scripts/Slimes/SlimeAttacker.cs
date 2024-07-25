
using System.Collections;
using UnityEngine;

public class SlimeAttacker : EnemyAttacker
{
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTime;
    [SerializeField] private int _attackDelay;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private int _projectilesAmount;
    [SerializeField] private float _projectilesRange;
    [SerializeField] private float _projectilesHeight;
    [SerializeField] private float _projectilesDamage;
    [SerializeField] private float _projectilesTime;

    private MovingAlongCurve _movingAlongCurve;
    private bool _isCanHurt;

    private void Awake()
    {
        _movingAlongCurve = GetComponent<MovingAlongCurve>();
        _animator = GetComponent<EnemyAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TargetLayer >> collision.gameObject.layer == 1)
        {
            var playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(_damage);
            StartCoroutine(WaitForAttack());
        }
    }
    public override void Attack()
    {
        _animator.Animator.SetBool(_animator.IsRunningId, false);
        _movingAlongCurve.Move(transform.position, _target.transform.position,
            Vector3.Lerp(transform.position, _target.transform.position, 0.5f) + new Vector3(0, _jumpHeight, 0), _jumpTime);

        StartCoroutine(WaitForGrounded());
    }

    private IEnumerator WaitForGrounded()
    {
        yield return new WaitUntil(() => _movingAlongCurve.Ended);
        _animator.Animator.SetBool(_animator.IsRunningId, true);
        _animator.Animator.SetBool(_animator.IsAttackId, false);

        LaunchProjectiles();

        StartCoroutine(WaitForAttack());
    }

    private void LaunchProjectiles()
    {
        for (int i = 0; i < _projectilesAmount; i++)
        {
            var direction = Random.Range(0, 2) == 0 ? Vector3.right : Vector3.left;
            var target = transform.position + (_projectilesRange * Random.Range(0.1f, 1f) * direction);
            target = new Vector3(target.x, target.y - 5, target.z);
            var projectile = Instantiate(_projectile, transform.position, _projectile.transform.rotation);
            var attacker = projectile.GetComponent<EnemyProjectileAttacker>();
            attacker.SetDamage(_projectilesDamage);
            projectile.gameObject
                .AddComponent<MovingAlongCurve>()
                .Move(transform.position, target, Vector3.Lerp(transform.position, target, 0.5f) +
                new Vector3(0, _projectilesHeight, 0), _projectilesTime)
                .RemoveWhenFinished();
        }
    }

    private IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(_attackDelay);
        _isCanAttack = true;
        StopAllCoroutines();
    }
}

