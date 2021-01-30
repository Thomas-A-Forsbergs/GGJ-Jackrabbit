using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    private EventsBroker _eventHandler;
    
    void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _eventHandler.SubscribeTo<LoseConditionEvent>(GameOver);
    }

    void GameOver(LoseConditionEvent argument)
    {
        Debug.Log("Event " + argument.GetType() + " fired!");
        _eventHandler.UnsubscribeFrom<LoseConditionEvent>(GameOver);
        Time.timeScale = 0;
    }
}
