using UnityEngine;
using UnityEngine.SceneManagement;

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
        _eventHandler.UnsubscribeFrom<LoseConditionEvent>(GameOver);
        SceneManager.LoadScene("LoseScene");
    }
}
