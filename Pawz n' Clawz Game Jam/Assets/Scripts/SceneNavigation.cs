using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void MenuButton()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);

    }

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
    }

    public void ManagerScene()
    {
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
    }
    
    public void PlayerSelection()
    {
        SceneManager.LoadSceneAsync(4, LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
