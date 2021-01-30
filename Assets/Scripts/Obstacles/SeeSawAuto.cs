using System;
using UnityEngine;

public class SeeSawAuto : MonoBehaviour {
    public float forceMultifier = 10f;
    public float velocity = 30f;
    private bool dirction;
    private JointMotor joint;
    private HingeJoint _hingeJoint;

    private void Start() {
        joint.force = forceMultifier;
        _hingeJoint = gameObject.GetComponent<HingeJoint>();
        joint.targetVelocity = velocity;
        _hingeJoint.motor = joint;
    }

    void Swing() {
        dirction = !dirction;
        joint.targetVelocity = dirction ? -velocity : velocity;
        _hingeJoint.motor = joint;

    }

    private void OnCollisionEnter(Collision collision) {
        // Debug.Log($"{collision.collider.name}");
        /*collision.collider.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up * forceMultifier,
            collision.contacts[0].point, ForceMode.Acceleration);*/
        Swing();
    }
}
