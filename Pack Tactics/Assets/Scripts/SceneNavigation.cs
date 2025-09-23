using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;
using PixelCrushers;
using UnityEngine.UI;
//using UnityEditor.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public float activationDelay = 3.0f; 
    public string sceneToLoadName = "Save Scene";

    public Canvas disableCanvas;

    public Camera targetCamera;


    public void LoadGame()
    {
        //SceneManager.UnloadSceneAsync("Menu Scene");
        //SceneManager.UnloadSceneAsync("Save Scene");
        SceneManager.LoadScene("Game Scene");
        SceneManager.UnloadScene("Player Character Select");

        //SceneManager.OpenScene("Game Scene");
    }

    public void LoadPlayerSelection()
    {
        SceneManager.LoadScene("Player Character Select");
        SceneManager.UnloadScene("Menu Scene");
    }

    public void LoadMercenary()
    {

        SceneManager.LoadScene("Mercenary Scene");
        SceneManager.UnloadScene("Player Character Select");
        SceneManager.UnloadSceneAsync("Save Scene");
    }

    public void LoadAverageJoe()
    {
        SceneManager.LoadScene("Average Joe Scene");
        SceneManager.UnloadScene("Player Character Select");
    }

    public void LoadCorporate()
    {
        SceneManager.LoadScene("Corporate Scene");
        SceneManager.UnloadScene("Player Character Select");
    }

    public void LoadDrifter()
    {
        SceneManager.LoadScene("Drifter Scene");
        SceneManager.UnloadScene("Player Character Select");
    }

    public void ReturnToCurrentGame()
    {
        if (disableCanvas == null)
        {
            disableCanvas.gameObject.SetActive(true);
        }
    }

    
    
    public void LoadSaveScene()
    {
        if (disableCanvas != null)
        {
            disableCanvas.gameObject.SetActive(false);
        }

        SceneManager.LoadSceneAsync(sceneToLoadName, LoadSceneMode.Additive);


    }

  

     
}
