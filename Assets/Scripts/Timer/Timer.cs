using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float gameTimerInSeconds;
    [SerializeField] private Text gameTimerTextObject;
    [SerializeField] private string gameTimerTextFormat = "Time Left:";
    
    private float timerInterval;
    private float elapsedTime;
    
    private bool TimeOut => gameTimerInSeconds <= 0f;
    
    private EventsBroker _eventHandler;
    private LoseConditionEvent _loseConditionEvent;
    
    void Start()
    {
        _eventHandler = FindObjectOfType<EventsBroker>();
        _loseConditionEvent = new LoseConditionEvent();
        timerInterval = 1.0f;
    }
    
    void Update()
    {
        if (!TimeOut)
        {
            UpdateTimer();
        }
        else
        {
            UpdateTimer();
            _eventHandler.Publish(_loseConditionEvent);
        }

        if (elapsedTime >= timerInterval)
        {
            gameTimerInSeconds -= timerInterval;
            elapsedTime -= timerInterval;
        }
        elapsedTime = elapsedTime + Time.deltaTime;
    }
    
    private void UpdateTimer()
    {
        if (gameTimerInSeconds < 0)
        {
            gameTimerInSeconds = 0;
        }
        gameTimerTextObject.text = $"{gameTimerTextFormat} {gameTimerInSeconds}s";
    }
}
