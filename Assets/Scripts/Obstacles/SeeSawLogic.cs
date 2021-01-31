using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSawLogic : MonoBehaviour
{
    private SeeSawObstacle[] launchPointRefs;
    
    private void Start()
    {
        launchPointRefs = GetComponentsInChildren<SeeSawObstacle>();
    }

    public void InitiateLaunch()
    {
        foreach (var launchPoint in launchPointRefs)
        {
            launchPoint.SeeSawLaunch();
        }
    }
}
