﻿using UnityEngine;

public class SwingSeatLogic : MonoBehaviour
{
    private PlayerMovement playerRef;
    
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerRef = other.gameObject.GetComponent<PlayerMovement>();
            playerRef.isStuck = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (playerRef != null)
        {
            playerRef.isStuck = false;
            playerRef = null;
        }
    }
}
