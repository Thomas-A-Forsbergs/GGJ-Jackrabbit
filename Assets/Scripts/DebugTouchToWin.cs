using UnityEngine;

public class DebugTouchToWin : MonoBehaviour
{
    private WinLoseConditionsBroker _eventHandler;
    private WinConditionEvent _winConditionEvent;

    
    // Start is called before the first frame update
    void Start()
    {
        _eventHandler = FindObjectOfType<WinLoseConditionsBroker>();
        _winConditionEvent = new WinConditionEvent();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")) _eventHandler.Publish(_winConditionEvent);
    }
}
