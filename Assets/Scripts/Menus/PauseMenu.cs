using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPrefab;

    private bool showingMenu;
    
    void Start()
    {
        showingMenu = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showingMenu)
            {
                pauseMenuPrefab.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseMenuPrefab.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            showingMenu = !showingMenu;
        }
    }


    public void ResumeButton()
    {
        pauseMenuPrefab.gameObject.SetActive(false);
        showingMenu = false;
        Time.timeScale = 1f;
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
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
