using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public KeyCode moveKey = KeyCode.Space;
    public float moveSpeed;

    private EventsBroker _eventHandler;
    private PlayerContextEvent _playerContextButtonEvent;
    
    public bool isStuck;

    private void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _playerContextButtonEvent = new PlayerContextEvent();

        isStuck = false;
    }


    public void Update()
    {
        if (Input.GetKey(moveKey) && !isStuck)
        {
            MoveInDirectionCameraIsPointing();
        }
        else if(Input.GetKeyDown(moveKey) && isStuck)
        {
            _eventHandler.Publish(_playerContextButtonEvent);
            this.isStuck = false;
        }
    }

    private void MoveInDirectionCameraIsPointing()
    {
        var dir = (Vector3.forward - cameraTransform.localPosition).normalized;
        transform.Translate(new Vector3(dir.x * Time.deltaTime * moveSpeed, 0, dir.z * Time.deltaTime * moveSpeed));
    }
}
