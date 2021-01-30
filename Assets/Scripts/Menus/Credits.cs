using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPrefab;
    
    public void BackToMain()
    {
        mainMenuPrefab.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
