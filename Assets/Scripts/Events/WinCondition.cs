using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winGameScreenPrefab;
    
    private EventsBroker _eventHandler;
    
    // Start is called before the first frame update
    void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _eventHandler.SubscribeTo<WinConditionEvent>(GameWin);
    }

    void GameWin(WinConditionEvent argument)
    {
        winGameScreenPrefab.SetActive(true);
        _eventHandler.UnsubscribeFrom<WinConditionEvent>(GameWin);
        Time.timeScale = 0;
    }
}
