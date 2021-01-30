using System;
using UnityEngine;
using UnityEngine.UI;

public class CurrentKeyUI : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<EventsBroker>().SubscribeTo(delegate(RandomKeyEvent keyEvent)
        {
            GetComponent<Text>().text = keyEvent.ToString();
        });
    }
}
