using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
public abstract class EnemyAttacker : MonoBehaviour, IAttacker
{
    [SerializeField] protected Collider2D _attackField;
    [SerializeField] protected int _damage;

    protected const int TargetLayer = 1 << 7;

    protected EnemyAnimator _animator;
    protected Collider2D _target;
    protected bool _isCanAttack = true;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimator>();
    }

    private void Update()
    {
        if(_isCanAttack)
            OverlapAttackField();
    }

    protected virtual void OverlapAttackField()
    {
        if (_attackField.IsTouchingLayers(TargetLayer) && _animator != null
            && _animator.Animator.GetBool(_animator.IsAttackId) == false)
        {
            if (_target == null)
                SetTarget();

            _animator.Animator.SetBool(_animator.IsAttackId, true);
            _isCanAttack = false;
        }
    }

    private void SetTarget()
    {
        List<Collider2D> targets = new();
        ContactFilter2D contactFilter = new();
        contactFilter.SetLayerMask(TargetLayer);
        contactFilter.useTriggers = true;
        _attackField.OverlapCollider(contactFilter, targets);

        if (targets.Count == 0)
            throw new System.Exception("Can not find target");
        _target = targets[0];
    }

    public abstract void Attack();
}
