using UnityEngine;

[RequireComponent (typeof(Animator))]
public class EnemyAnimator : MonoBehaviour, IInitializable
{
    private const string IsAttack = "IsAttack";
    private const string IsRunning = "IsRunning";
    private const string IsDied = "IsDied";
    private const string IsHurt = "IsHurt";

    private int _isAttackId;
    private int _isRunningId;
    private int _isDiedId;
    private int _isHurtId;
    private Animator _animator;

    public int IsAttackId => _isAttackId;
    public int IsRunningId => _isRunningId;
    public int IsDiedId => _isDiedId;
    public int IsHurtId => _isHurtId;
    public Animator Animator => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Initialize()
    {
        _isRunningId = Animator.StringToHash(IsRunning);
        _isAttackId = Animator.StringToHash(IsAttack);
        _isDiedId = Animator.StringToHash(IsDied);
        _isHurtId = Animator.StringToHash(IsHurt);
    }
}

