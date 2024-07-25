using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject _mapTile;
    [SerializeField] private float _segmentSize = 3f;
    [SerializeField] private float _updateThreshold = 10f;
    [SerializeField] private int _segmentsVisibleInView = 7;

    private Dictionary<Vector2, GameObject> _segments = new();
    private Vector2 _lastPlayerPosition;

    private void Start()
    {
        _lastPlayerPosition = new Vector2(
            Mathf.Floor(_player.position.x / _segmentSize),
            Mathf.Floor(_player.position.y / _segmentSize)
        );
        InitializeMap();
    }

    private void Update()
    {
        Vector2 currentPlayerPosition = new Vector2(
            Mathf.Floor(_player.position.x / _segmentSize),
            Mathf.Floor(_player.position.y / _segmentSize)
        );

        if (Vector2.Distance(_player.position, _lastPlayerPosition * _segmentSize) > _updateThreshold)
        {
            _lastPlayerPosition = currentPlayerPosition;
            UpdateMap();
        }
    }

    private void InitializeMap()
    {
        for (int x = -_segmentsVisibleInView; x <= _segmentsVisibleInView; x++)
        {
            for (int y = -_segmentsVisibleInView; y <= _segmentsVisibleInView; y++)
            {
                var segmentPosition = new Vector2(
                    (_lastPlayerPosition.x + x) * _segmentSize,
                    (_lastPlayerPosition.y + y) * _segmentSize
                );

                if (_segments.ContainsKey(segmentPosition) == false)
                {
                    var segment = Instantiate(_mapTile, segmentPosition, Quaternion.identity, transform);
                    _segments.Add(segmentPosition, segment);
                }
            }
        }
    }

    private void UpdateMap()
    {
        List<Vector2> newPositions = new();

        for (int x = -_segmentsVisibleInView; x <= _segmentsVisibleInView; x++)
        {
            for (int y = -_segmentsVisibleInView; y <= _segmentsVisibleInView; y++)
            {
                Vector2 segmentPosition = new Vector2(
                    (_lastPlayerPosition.x + x) * _segmentSize,
                    (_lastPlayerPosition.y + y) * _segmentSize
                );

                newPositions.Add(segmentPosition);

                if (_segments.ContainsKey(segmentPosition) == false)
                {
                    var recycledSegment = GetRecycledSegment();
                    if (recycledSegment != null)
                    {
                        recycledSegment.transform.position = segmentPosition;
                        _segments.Add(segmentPosition, recycledSegment);
                    }
                    else
                    {
                        var segment = Instantiate(_mapTile, segmentPosition, Quaternion.identity, transform);
                        _segments.Add(segmentPosition, segment);
                    }
                }
            }
        }
        var segmentsToRemove = new List<Vector2>();

        foreach (var segment in _segments)
            if (newPositions.Contains(segment.Key) == false)
                segmentsToRemove.Add(segment.Key);

        foreach (var segmentPosition in segmentsToRemove)
        {
            Destroy(_segments[segmentPosition].gameObject);
            _segments.Remove(segmentPosition);
            
        }
    }

    private GameObject GetRecycledSegment()
    {
        foreach (var segment in _segments)
        {
            if (segment.Value.activeSelf == false)
            {
                segment.Value.SetActive(true);
                return segment.Value;
            }
        }
        return null;
    }
}
