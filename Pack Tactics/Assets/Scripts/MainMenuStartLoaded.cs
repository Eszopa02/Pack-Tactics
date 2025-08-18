using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStartLoaded : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.UnloadSceneAsync("Game Scene");
        SceneManager.LoadScene("Main Menu");
        SceneManager.UnloadSceneAsync("Manager Scene");
    }
}
