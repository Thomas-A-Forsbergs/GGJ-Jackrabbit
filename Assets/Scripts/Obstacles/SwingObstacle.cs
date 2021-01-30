using System;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    private GameObject playerRef;
    private bool onSwing;
    [SerializeField]private Transform launchpointAnchor;
    [SerializeField]private Transform seatAnchor;
    private Vector3 seatAnchorPos;
    
    [SerializeField] private float launchForce = 2f;

    private void Start()
    {
        onSwing = false;
    }
    
    private void Update()
    {
        seatAnchorPos = launchpointAnchor.transform.position;
        if (onSwing)
        {
            playerRef.transform.position = seatAnchorPos;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        playerRef = collision.collider.gameObject;
        playerRef.transform.position = seatAnchorPos;
        playerRef.GetComponent<PlayerMovement>().isStuck = true;
        onSwing = true;
    }

    public void SwingLaunch()
    {
        if (onSwing)
        {
            onSwing = false;
            playerRef.transform.position = launchpointAnchor.transform.position;
            playerRef.GetComponent<Rigidbody>().AddForce(launchpointAnchor.transform.forward * launchForce);
            playerRef.GetComponent<PlayerMovement>().isStuck = false;
            playerRef = null;
        }
    }
}