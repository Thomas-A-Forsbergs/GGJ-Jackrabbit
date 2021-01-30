using UnityEngine;

public class DebugTouchToWin : MonoBehaviour
{
    private EventsBroker _eventHandler;
    private WinConditionEvent _winConditionEvent;

    
    // Start is called before the first frame update
    void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _winConditionEvent = new WinConditionEvent();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")) _eventHandler.Publish(_winConditionEvent);
    }
}