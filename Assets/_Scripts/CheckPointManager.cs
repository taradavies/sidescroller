using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    CheckPoint[] _checkPoints;
    void Start()
    {
        _checkPoints = GetComponentsInChildren<CheckPoint>();
    }

    public CheckPoint GetLastCheckPointPassed() 
    {
        // t.PassedCheckPoint returns true if it was passed
        return _checkPoints.LastOrDefault(t => t.PassedCheckPoint);
    }
}
