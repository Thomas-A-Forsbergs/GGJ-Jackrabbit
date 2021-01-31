using System;
using UnityEngine;

public class SeeSawObstacle : MonoBehaviour
{
    private GameObject playerRef;
    private bool onSeeSaw;
    [SerializeField]private Transform launchpointAnchor;
    //[SerializeField]private Transform seatAnchor;
    private Vector3 seatAnchorPos;

    [SerializeField] private bool shouldLaunch;
    [SerializeField] private float launchForce = 2f;

    private void Start()
    {
        onSeeSaw = false;
    }
    
    private void Update()
    {
        seatAnchorPos = launchpointAnchor.transform.position;
        if (onSeeSaw)
        {
            playerRef.transform.position = seatAnchorPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerRef = other.gameObject;
        playerRef.transform.position = seatAnchorPos;
        playerRef.GetComponent<PlayerMovement>().isStuck = true;
        onSeeSaw = true;
    }

    // void OnTriggerEnter(Collider collision)
    // {
    //     playerRef = collision.gameObject;
    //     playerRef.transform.position = seatAnchorPos;
    //     playerRef.GetComponent<PlayerMovement>().isStuck = true;
    //     onSeeSaw = true;
    // }

    public void SeeSawLaunch()
    {
        if (onSeeSaw && shouldLaunch)
        {
            onSeeSaw = false;
            playerRef.transform.position = launchpointAnchor.transform.position;
            playerRef.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            playerRef.GetComponent<Rigidbody>().AddForce(launchpointAnchor.transform.forward * launchForce);
            playerRef.GetComponent<PlayerMovement>().isStuck = false;
            playerRef = null;
        }
        shouldLaunch = !shouldLaunch;
    }
}