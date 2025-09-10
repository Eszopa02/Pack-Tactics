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

<<<<<<< HEAD
    public void PlayerCharacterSelection()
    {
        SceneManager.LoadScene("Player Character Selection Scene");
        SceneManager.UnloadSceneAsync("Menu Scene");
    }

=======
    public void PlayButton()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
    }

    public void ManagerScene()
    {
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
>>>>>>> parent of 04fe1976 (Scene Transition from Main Menu to Game)
}
