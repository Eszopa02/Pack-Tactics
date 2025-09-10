using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    /* public void MenuButton()
     {
         SceneManager.LoadScene(1, LoadSceneMode.Additive);

     }

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
     } */

    public void GameScene()
    {
        SceneManager.LoadScene("Game Scene");
        SceneManager.UnloadSceneAsync("Main Menu");
        SceneManager.LoadScene("Manager Scene");
    }

    public void PlayerCharacterSelection()
    {
        SceneManager.LoadScene("Player Character Selection Scene");
        SceneManager.UnloadSceneAsync("Menu Scene");
    }

}
