using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play pressed");
        SceneManager.LoadScene("Lv1");
    }
}
