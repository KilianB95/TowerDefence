using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Waypoints[] _waypoints;
    
    public Waypoints GetPathStart()
    {
        Debug.Log(_waypoints.Length);
        return _waypoints[0];
    }

    public Waypoints GetPathEnd()
    {
        return _waypoints[_waypoints.Length - 1];
    }

    public Waypoints GetNextWaypoints(Waypoints currentWaypoints)
    {
        for(int i = 0; i < _waypoints.Length; i++)
        {
            if (_waypoints[i] == currentWaypoints)
            {
                return _waypoints[i + 1];
            }
        }
        return null;
    }
}
