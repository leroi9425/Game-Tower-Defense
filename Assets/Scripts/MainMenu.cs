using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
    {
        Debug.Log("play game");
        SceneManager.LoadSceneAsync(1);
    }
    public void BackToMenu()
    {
        Debug.Log("Go back");
        SceneManager.LoadSceneAsync(0);
    }
}