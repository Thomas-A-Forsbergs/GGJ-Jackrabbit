using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public KeyBind[] moveKeys;
    public float moveSpeed;
    private int _keyIndex;
    private int _animState = 1;
    private bool _justMoved;

    private EventsBroker _eventHandler;
    private PlayerContextEvent _playerContextButtonEvent;
    
    public bool isStuck;

    private void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _playerContextButtonEvent = new PlayerContextEvent();

        isStuck = false;
        RandomizeInput();
    }


    public void Update()
    {
        if (_justMoved) return;
        var currentKeyBind = moveKeys[_keyIndex];
        foreach (var keyCode in currentKeyBind.codes)
        {
            if (Input.GetKeyDown(keyCode) && !isStuck)
            {
                Walk();
            }
            else if (Input.GetKeyDown(keyCode) && isStuck)
            {
                _eventHandler.Publish(_playerContextButtonEvent);
                this.isStuck = false;
                RandomizeInput();
            }
        }

        foreach (var axis in currentKeyBind.axes)
        {
            if (Input.GetAxis(axis) >= 0.9f && !isStuck)
            {
                Walk();
            }
            else if (Input.GetAxis(axis) >= 0.9f && isStuck)
            {
                _eventHandler.Publish(_playerContextButtonEvent);
                this.isStuck = false;
                RandomizeInput();
            }
        }
    }

    private void Walk()
    {
        StartCoroutine(Move());
        _justMoved = true;
        StartCoroutine(ResetDelay());
        _eventHandler.Publish(new WalkEvent(_animState));
        _animState++;
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

    private IEnumerator Move()
    {
        var timer = 0.5f; 
        while (true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                break;
            }
            MoveInDirectionCameraIsPointing();

            yield return null;
        }
    }

    private IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(0.5f);
        RandomizeInput();
        _justMoved = false;
    }
}

[System.Serializable]
public class KeyBind
{
    public KeyCode[] codes;
    public string[] axes;

    public override string ToString()
    {
        var fullString = codes.Aggregate("", (current, keyCode) => current + (keyCode + " "));

        return axes.Aggregate(fullString, (current, axis) => current + (axis + " "));
    }
}