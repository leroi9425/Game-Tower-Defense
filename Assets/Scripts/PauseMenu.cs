using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pause_menu;

    public void Pause()
    {
        Debug.Log("Pause pressed");
        pause_menu.SetActive(true);
    }
    public void Resume()
    {
        Debug.Log("Resume pressed");
        pause_menu.SetActive(false);
    }
    public void Restart()
    {
        Debug.Log("Restart pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Home()
    {
        Debug.Log("Home pressed");
        SceneManager.LoadScene("MainMenu");
    }
}
