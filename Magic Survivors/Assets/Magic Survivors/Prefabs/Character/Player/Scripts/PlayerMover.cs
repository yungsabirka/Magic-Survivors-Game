using UnityEngine;

[RequireComponent (typeof(PlayerAnimator))]
[RequireComponent (typeof(PlayerHealth))]
[RequireComponent (typeof(SpriteRenderer))]
public class PlayerMover : MonoBehaviour, IInitializable
{
    [SerializeField] private InputController _inputController;
    [SerializeField] private Transform _flippedObjects;

    private SpriteRenderer _spriteRenderer;
    private PlayerAnimator _animator;
    private PlayerHealth _health;
    private PlayerInfoInteractor _interactor;

    private float _speed;
    private Vector2 _direction;
    private bool _isDied;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<PlayerAnimator>();
        _health = GetComponent<PlayerHealth>();
    }

    public void Initialize()
    {
        _interactor = Game.GetInteractor<PlayerInfoInteractor>();
        Game.GetInteractor<PlayerInfoInteractor>().StatsChanged += SetSpeed;
        _health.Died += SetDeath;
        SetSpeed();
    }

    private void OnDestroy()
    {
        Game.GetInteractor<PlayerInfoInteractor>().StatsChanged -= SetSpeed;
        _health.Died -= SetDeath;
    }

    private void Update()
    {
        if (_isDied)
            return;

        if (_inputController != null && _inputController.Initialized)
            _direction = _inputController.GameplayInput.KeyBoardAndMouse.Move.ReadValue<Vector2>();

        Move();
        AnimateMoving();
    }

    private void Move()
    {
        if (_direction.sqrMagnitude < 0.1f)
            return;

        float scaledMoveSpeed = _speed * Time.deltaTime;
        Vector3 offset = (Vector3)_direction * scaledMoveSpeed;

        transform.Translate(offset);
        FlipX(_direction.x);

        _interactor.SetPosition(transform.position);
    }

    private void FlipX(float x)
    {
        if (x == 0)
            return;

        var lookSide = x > 0 ? 1 : -1;
        var localScale = new Vector3(lookSide, 1, 1);
        _flippedObjects.transform.localScale = localScale;
        _spriteRenderer.flipX = x < 0;
    }

    private void AnimateMoving()
    {
        if (_animator == null)
            return;

        var isMoving = _direction.sqrMagnitude > 0.1f;
        _animator.Animator.SetBool(_animator.IsRunningId, isMoving);
    }

    private void SetSpeed()
        => _speed = Game.GetInteractor<PlayerInfoInteractor>().CurrentStats.Speed;

    private void SetDeath() => _isDied = true;
}
