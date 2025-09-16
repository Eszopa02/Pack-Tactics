using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
   

    public void LoadGame()
    {
        //SceneManager.UnloadSceneAsync("Menu Scene");
        //SceneManager.UnloadSceneAsync("Save Scene");
        SceneManager.LoadScene("Game Scene");
        
        //SceneManager.OpenScene("Game Scene");
    }

    public void SaveScreen()
    {
        //SceneManager.UnloadSceneAsync("Game Scene");
        //SceneManager.UnloadSceneAsync("Menu Scene");
        SceneManager.LoadScene("Save Scene");
        SceneManager.UnloadScene("Game Scene");
        //SceneManager.OpenScene("Save Scene");
        //EditorSceneManager.OpenScene();

        //EditorSceneManager.CloseScene(SceneManager.GetSceneByName("Game Scene"), true);
        //EditorSceneManager.OpenScene(SceneManager.GetSceneByName("Save Scene"), true);
    }

    
}
