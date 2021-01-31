using UnityEngine;
using UnityEngine.SceneManagement;

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
        _eventHandler.UnsubscribeFrom<WinConditionEvent>(GameWin);
        SceneManager.LoadScene("WinScene");
    }
}
