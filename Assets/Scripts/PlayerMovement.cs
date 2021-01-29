using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform, forwardTransform;
    public KeyCode moveKey = KeyCode.Space;
    public float moveSpeed;

    public void Update()
    {
        if (Input.GetKey(moveKey))
        {
            MoveInDirectionCameraIsPointing();
        }
    }

    private void MoveInDirectionCameraIsPointing()
    {
        var forward = cameraTransform.forward;
        var dir = (Vector3.forward - cameraTransform.localPosition).normalized;
        transform.Translate(new Vector3(dir.x * Time.deltaTime * moveSpeed, 0, dir.z * Time.deltaTime * moveSpeed));
    }
}
