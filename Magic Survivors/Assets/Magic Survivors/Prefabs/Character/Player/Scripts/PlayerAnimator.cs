using UnityEngine;

[RequireComponent (typeof(Animator))]
public class PlayerAnimator : MonoBehaviour, IInitializable
{
    private const string IsRunning = "IsRunning";
    private const string IsAttack = "IsAttack";
    private const string IsDied = "IsDied";

    private Animator _animator;
    private int _isRunningId;
    private int _isAttackId;
    private int _isDiedId;

    public Animator Animator => _animator;
    public int IsRunningId => _isRunningId;
    public int IsAttackId => _isAttackId;
    public int IsDiedId => _isDiedId;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Initialize()
    {
        _isRunningId = Animator.StringToHash(IsRunning);
        _isAttackId = Animator.StringToHash(IsAttack);
        _isDiedId = Animator.StringToHash(IsDied);
    }
}
