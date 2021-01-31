using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private Text text;
    private void Awake()
    {
        FindObjectOfType<EventsBroker>().SubscribeTo<TimeLeftEvent>(UpdateTime);
    }

    private void UpdateTime(TimeLeftEvent timeLeftEvent)
    {
        text.text = timeLeftEvent.TimeLeft;
    }
}
