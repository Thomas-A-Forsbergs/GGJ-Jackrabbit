using System;
using UnityEngine;

public class CurrentKeyDebugger : MonoBehaviour
{
    private void Awake()
    {
        FindObjectOfType<EventsBroker>().SubscribeTo<RandomKeyEvent>(DebugKey);
    }

    private void DebugKey(RandomKeyEvent keyEvent)
    {
        Debug.Log(keyEvent);
    }
}
