using UnityEngine;

public class MovingAlongCircle : MonoBehaviour
{
    [SerializeField] private Transform _center;

    private float _angularSpeed;
    private TridentsInteractor _interactor;

    private void Start()
    {
        Game.OnGameInitialized += Initialize;
    }

    private void OnDisable()
    {
        _interactor.AngularSpeedChanged -= SetAngularSpeed;
    }

    private void Update()
    {
        transform.RotateAround(_center.position, Vector3.forward, _angularSpeed * Time.deltaTime);
    }

    private void Initialize()
    {
        _interactor = Game.GetInteractor<TridentsInteractor>();
        _interactor.AngularSpeedChanged += SetAngularSpeed;
        SetAngularSpeed(_interactor.AngularSpeed);
        Game.OnGameInitialized -= Initialize;
    }

    private void SetAngularSpeed(float angularSpeed) => _angularSpeed = angularSpeed;
}

