using UnityEngine;

[RequireComponent (typeof(EnemyHealth))]
[RequireComponent (typeof(EnemyAnimator))]
public class EnemyMover : MonoBehaviour, IInitializable
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _ui;

    private EnemyHealth _health;
    private EnemyAnimator _animator;
    private PlayerInfoInteractor _interactor;
    private Vector3 _targetPosition;
    private bool _isCanMoving;

    private void Awake()
    {
        _health = GetComponent<EnemyHealth>();
        _animator = GetComponent<EnemyAnimator>();
    }

    public void Initialize()
    {
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
        _isCanMoving = true;
        _health.Died += OnDie;

        if (transform.localScale.y > 1)
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).localScale /= transform.localScale.y;
    }

    private void Update()
    {
        if (_isCanMoving && _health.IsDied == false)
            Move();
    }

    private void Move()
    {
        _targetPosition = _interactor.Position;
        var direction = (_targetPosition - transform.position).normalized;
        var velocity = _speed * Time.deltaTime * direction;

        transform.Translate(velocity);

        var lookSide = direction.x > 0 ? -1 : 1;
        
        transform.localScale = GetFlippedVector(transform.localScale, lookSide);
        _ui.localScale = GetFlippedVector(_ui.transform.localScale, lookSide);

        _animator.Animator.SetBool(_animator.IsRunningId, true);
    }

    private Vector3 GetFlippedVector(Vector3 localScale, int lookSide)
        => new(Mathf.Abs(localScale.x) * lookSide, localScale.y, localScale.z);

    public void StartMoving() => _isCanMoving = true;

    public void StopMoving() => _isCanMoving = false;

    private void OnDie()
    {
        _isCanMoving = false;
        _health.Died -= OnDie;
    }
}

