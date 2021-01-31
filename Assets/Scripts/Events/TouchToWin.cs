using UnityEngine;

public class TouchToWin : MonoBehaviour
{
    private EventsBroker _eventHandler;
    private WinConditionEvent _winConditionEvent;
    
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