using System;
using UnityEngine;

public class MoveBetween : MonoBehaviour
{
    private EventsBroker _eventHandler;
    private SwingLetGoEvent _swingLetGoEvent;

    [SerializeField]private GameObject[] children;
    
    public Transform pos1, pos2;
    public float speed;
    private float currentLerp;
    private bool moveBack;
    
    private bool test;
    
    private void Start()
    {
        //transform.DetachChildren();
        
        _eventHandler = FindObjectOfType<EventsBroker>();
        _eventHandler.SubscribeTo<GotPlayerEvent>(SwingLetGo);
    }

    private void Update()
    {
        transform.position = moveBack ? Vector3.Lerp(pos2.position, pos1.position, currentLerp) : Vector3.Lerp(pos1.position, pos2.position, currentLerp);

        currentLerp += speed * Time.deltaTime;
        if (currentLerp >= 1)
        {
            currentLerp = 0;
            moveBack = !moveBack;
            //Invoke(nameof(TurnOn), 0);
            //Invoke(nameof(TurnOff), .4f);
        }
    }

    void SwingLetGo(GotPlayerEvent argument)
    {
        _swingLetGoEvent = new SwingLetGoEvent();
    }

    void TurnOn()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetActive(true);
        }
    }
    
    void TurnOff()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].SetActive(false);
        };    
    }
}