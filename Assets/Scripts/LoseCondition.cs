using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    private WinLoseConditionsBroker _eventHandler;
    
    void Start()
    {
        _eventHandler = FindObjectOfType<WinLoseConditionsBroker>();
        _eventHandler.SubscribeTo<string>(GameOver);
    }

    void GameOver(string argument)
    {
        Debug.Log("Event" + argument + "fired");
        _eventHandler.UnsubscribeFrom<string>(GameOver);
        Time.timeScale = 0;
    }
}
