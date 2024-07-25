using UnityEngine;

public class MagixBookProjectileMover : MonoBehaviour
{
    private MagixBookInteractor _interactor;
    private float _speed;

    private void Start()
    {
        _interactor = Game.GetInteractor<MagixBookInteractor>();
        _interactor.StatsChanged += SetSpeed;
        SetSpeed();
    }

    private void Update()
    {
        if (_speed <= 0)
            return;

        transform.Translate(_speed * Time.deltaTime * Vector3.right);
    }

    private void OnDisable()
    {
        _interactor.StatsChanged -= SetSpeed;
    }

    public void SetSpeed() => _speed = _interactor.CurrentStats.ProjectilesMovingSpeed;
}
