using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private EventsBroker _eventHandler;
    
    // Start is called before the first frame update
    void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _eventHandler.SubscribeTo<WinConditionEvent>(GameWin);
    }

    void GameWin(WinConditionEvent argument)
    {
        Debug.Log("Event " + argument.GetType() + " fired!");
        _eventHandler.UnsubscribeFrom<WinConditionEvent>(GameWin);
        Time.timeScale = 0;
    }
}
