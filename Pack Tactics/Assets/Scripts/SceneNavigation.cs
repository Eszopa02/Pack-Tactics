using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
   

    public void LoadGame()
    {
        SceneManager.UnloadSceneAsync("Menu Scene");
        SceneManager.LoadScene("Game Scene");
    }
}
