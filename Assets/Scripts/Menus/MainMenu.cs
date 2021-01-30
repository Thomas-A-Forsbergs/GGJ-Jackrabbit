using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPrefab;
    [SerializeField] private GameObject mainMenuPrefab;
    
    public void StartGameButton()
    {
        //Loads the next scene in the build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void ShowCredits()
    {
        creditsPrefab.SetActive(true);
        mainMenuPrefab.SetActive(false);
    }
    
    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
