using System;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    public event Action<Item> Arrived;

    [SerializeField] private float _speed;
    [SerializeField] private float _arrivedDistance;

    private Transform _target;

    public Transform Target => _target;

    private void Update()
    {
        if (_target == null)
            return;

        var direction = _target.position - transform.position;

        if (direction.magnitude < _arrivedDistance)
            Arrived.Invoke(GetComponent<Item>());
        else
            transform.Translate(Time.deltaTime * _speed * direction);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
