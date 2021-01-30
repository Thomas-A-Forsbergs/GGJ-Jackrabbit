using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public KeyCode[] moveKeys;
    public float moveSpeed;
    private int _keyIndex;

    private EventsBroker _eventHandler;
    private PlayerContextEvent _playerContextButtonEvent;
    
    public bool isStuck;

    private void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _playerContextButtonEvent = new PlayerContextEvent();

        isStuck = false;
        _keyIndex = Random.Range(0, moveKeys.Length);
    }


    public void Update()
    {
        if (Input.GetKeyDown(moveKeys[_keyIndex]) && !isStuck)
        {
            MoveInDirectionCameraIsPointing();
            RandomizeInput();
        }
        else if(Input.GetKeyDown(moveKeys[_keyIndex]) && isStuck)
        {
            _eventHandler.Publish(_playerContextButtonEvent);
            this.isStuck = false;
            RandomizeInput();
        }
    }

    private void RandomizeInput()
    {
        _keyIndex = Random.Range(0, moveKeys.Length);
        _eventHandler.Publish(new RandomKeyEvent(moveKeys[_keyIndex]));
    }

    private void MoveInDirectionCameraIsPointing()
    {
        var dir = (Vector3.forward - cameraTransform.localPosition).normalized;
        transform.Translate(new Vector3(dir.x * Time.deltaTime * moveSpeed, 0, dir.z * Time.deltaTime * moveSpeed));
    }
}
