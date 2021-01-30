using System;
using UnityEngine;

public class SpinningWheel : MonoBehaviour
{
    private GameObject player;
    private FixedJoint _fixedJoint;
    [SerializeField] private Transform attachmentPoint;
    private Vector3 attachmentPointPos;
    private bool onWheel;
    public float forceMultifier = 1;

    private EventsBroker _eventHandler;

    private void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        attachmentPointPos = attachmentPoint.transform.position;
    }

    private void Update()
    {
        attachmentPointPos = attachmentPoint.transform.position;
        
        if (onWheel)
        {
            player.transform.position = attachmentPointPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        player = collision.collider.gameObject;
        //Vector3 pos = player.transform.position;
        //var dir = transform.position - pos;
        //pos += dir.normalized * 2f;
        //pos.y += 0.2f;
        player.transform.position = attachmentPointPos;
        //_fixedJoint = player.AddComponent<FixedJoint>();
        //_fixedJoint.connectedBody = this.GetComponent<Rigidbody>();
        player.GetComponent<PlayerMovement>().isStuck = true;
        onWheel = true;
        _eventHandler.SubscribeTo<PlayerContextEvent>(Release);
    }

    void Release(PlayerContextEvent argument)
    {
        onWheel = false;
        
        var dir = attachmentPoint.transform.forward; 
        var forceDir = dir.normalized * forceMultifier;
        player.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Impulse);
        player.GetComponent<PlayerMovement>().isStuck = false;
        _eventHandler.UnsubscribeFrom<PlayerContextEvent>(Release);
    }
}
