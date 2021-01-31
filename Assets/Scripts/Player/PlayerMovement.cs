using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public KeyBind[] moveKeys;
    public KeyBind contextKeys = new KeyBind(KeyCode.Space, KeyCode.Joystick1Button0);
    public float moveSpeed;
    private int _keyIndex;
    private int _animState = 1;
    private bool _justMoved;

    private EventsBroker _eventHandler;

    private bool _isStuck;
    public bool isStuck
    {
        get => _isStuck;
        set
        {
            _isStuck = value;
            if (value == false)
            {
                RandomizeInput();
            }
        }
    }

    private void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _eventHandler.SubscribeTo<ShowContextButton>(ShowContext);

        isStuck = false;
        RandomizeInput();
    }

    private void ShowContext(ShowContextButton contextButton)
    {
        _eventHandler.Publish(new RandomKeyEvent(contextKeys));
    }


    public void Update()
    {
        if (_justMoved) return;

        foreach (var keyCode in contextKeys.codes)
        {
            if (isStuck && Input.GetKeyDown(keyCode))
            {
                _eventHandler.Publish(new PlayerContextEvent());
            }
        }
        var currentKeyBind = moveKeys[_keyIndex];
        foreach (var keyCode in currentKeyBind.codes)
        {
            if (Input.GetKeyDown(keyCode) && !isStuck)
            {
                Walk();
            }
        }

        foreach (var axis in currentKeyBind.axes)
        {
            if (Input.GetAxis(axis) >= 0.9f && !isStuck)
            {
                Walk();
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
        var index = _keyIndex;
        do
        { 
            _keyIndex = Random.Range(0, moveKeys.Length);
        } while (index == _keyIndex);
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
        if (!isStuck)
            RandomizeInput();
        _justMoved = false;
    }
}

[System.Serializable]
public class KeyBind
{
    public KeyCode[] codes;
    public string[] axes;

    public KeyBind(params KeyCode[] keyCode)
    {
        codes = keyCode;
    }

    public override string ToString()
    {
        var fullString = codes.Aggregate("", (current, keyCode) => current + (keyCode + " "));

        return axes.Aggregate(fullString, (current, axis) => current + (axis + " "));
    }
}