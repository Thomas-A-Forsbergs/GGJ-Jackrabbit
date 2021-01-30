using System;
using UnityEngine;

public class SpinningWheel : MonoBehaviour {
    private GameObject player;
    private FixedJoint _fixedJoint;
    private bool onWheel;
    // public float forceMultifier = 1;
    private void OnCollisionEnter(Collision collision) {
        player = collision.collider.gameObject;
        Vector3 pos = player.transform.position;
        var dir = transform.position - pos;
        pos += dir.normalized * 2f;
        pos.y +=0.2f;
        player.transform.position = pos;
        _fixedJoint = player.AddComponent<FixedJoint>();
        _fixedJoint.connectedBody = this.GetComponent<Rigidbody>();
        onWheel = true;
    }

    private void OnCollisionExit(Collision collision) {
        _fixedJoint.connectedBody = null;
        Destroy(_fixedJoint);
        onWheel = false;
    }

    // private void Update() {
    //     Debug.Log($"{onWheel}");
    //     if(Input.GetKey(KeyCode.R) & onWheel) {
    //         Debug.Log($"releasing!");
    //         Destroy(_fixedJoint);
    //         var dir = transform.position - player.transform.position;
    //         var forceDir = dir.normalized * forceMultifier;
    //         player.GetComponent<Rigidbody>().AddForce(forceDir, ForceMode.Impulse);
    //     }
            
    }
