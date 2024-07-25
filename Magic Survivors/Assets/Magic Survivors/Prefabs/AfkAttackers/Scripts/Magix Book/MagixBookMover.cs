using UnityEngine;

public class MagixBookMover : MonoBehaviour
{
    private MagixBookInteractor _interactor;
    private Transform _nextPoint;
    private int _index = 0;
    private float _minDistance = 0.1f;
    private float _speed;

    private void Start()
    {
        _interactor = Game.GetInteractor<MagixBookInteractor>();
        _interactor.StatsChanged += SetSpeed;
        _nextPoint = _interactor.MovingPoints[_index];
        _index++;

        SetSpeed();
    }

    private void Update()
    {
        if (_interactor == null)
            return;

        var direction = _nextPoint.position - transform.position;
        transform.Translate(_speed * Time.deltaTime * direction);

        var distance = Vector3.Distance(_nextPoint.position, transform.position);
        if (distance < _minDistance)
        {
            _nextPoint = _interactor.MovingPoints[_index];
            _index = (_index + 1) % _interactor.MovingPoints.Count;
        }
    }

    public void SetSpeed() => _speed = _interactor.CurrentStats.MagixBookMovingSpeed;
}

