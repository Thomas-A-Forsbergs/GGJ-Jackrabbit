using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float gameTimerInSeconds;
    private float timerInterval;
    private float elapsedTime;
    
    private bool TimerOut => gameTimerInSeconds <= 0;
    
    private WinLoseConditionsBroker _eventHandler;
    
    void Start()
    {
        _eventHandler = FindObjectOfType<WinLoseConditionsBroker>();
        timerInterval = 1.0f;
    }
    
    void Update()
    {
        if (TimerOut) TimeOut();
        elapsedTime = elapsedTime + Time.deltaTime;
        
        if (elapsedTime >= timerInterval)
        {
            gameTimerInSeconds -= timerInterval;
            elapsedTime -= timerInterval;
        }
    }

    void TimeOut()
    {
        _eventHandler.Publish("TimeOut");
    }
}
