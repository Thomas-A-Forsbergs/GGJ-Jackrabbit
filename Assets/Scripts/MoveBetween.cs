using System;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    private float currentLerp;
    private bool moveBack;

    private void Start()
    {
        transform.DetachChildren();
    }

    private void Update()
    {
        transform.position = moveBack ? Vector3.Lerp(pos2.position, pos1.position, currentLerp) : Vector3.Lerp(pos1.position, pos2.position, currentLerp);

        currentLerp += speed * Time.deltaTime;
        if (currentLerp >= 1)
        {
            currentLerp = 0;
            moveBack = !moveBack;
        }
    }
}