using System;
using UnityEngine;

public class MatchRelativeTransform : MonoBehaviour
{
    public Transform transformToFollow;
    private Vector3 _startPos;

    private void Awake()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        transform.position = transformToFollow.position + _startPos;
    }
}
