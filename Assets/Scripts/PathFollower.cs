using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _arrivalThreshold;

    private Path _path;
    private Waypoints _currentWaypoints;

    private void Start()
    {
        SetupPath();
    }

    private void Update()
    {
        transform.Translate(translation: Vector3.forward * _speed * Time.deltaTime);

        float distanceToWaypoints = Vector3.Distance(transform.position, _currentWaypoints.Getposition()); 
        if(distanceToWaypoints <= _arrivalThreshold)
        {
            if(_currentWaypoints == _path.GetPathEnd())
            {
                PathComplete();
            }
            else
            {
                _currentWaypoints = _path.GetNextWaypoints(_currentWaypoints);
                transform.LookAt(_currentWaypoints.Getposition());
            }
        }
    }

    private void SetupPath()
    {
        _path = FindObjectOfType<Path>();
        _currentWaypoints = _path.GetPathStart();
        transform.LookAt(_currentWaypoints.Getposition());
    }

    private void PathComplete()
    {
        _speed = 0;
        
    }
}
