using System;
using UnityEngine;

public class MatchTransform : MonoBehaviour
{
    public Transform transformToFollow;

    private void Update()
    {
        transform.position = transformToFollow.position;
    }
}
