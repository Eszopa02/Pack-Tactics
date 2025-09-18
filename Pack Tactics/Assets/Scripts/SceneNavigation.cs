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

    public void LoadGame()
    {
        //Load/Start Dialogue Manager after Save Screen Pause
        DialogueManager.displaySettings.defaultCanvas.enabled = true;
        ConversationPositionStack.PopConversationPosition();

        //SceneManager.UnloadSceneAsync("Menu Scene");
        //SceneManager.UnloadSceneAsync("Save Scene");
        SceneManager.LoadScene("Game Scene");
        SceneManager.UnloadScene("Player Character Select");
        SceneManager.UnloadScene("Save Scene");
        
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
    
    public void LoadSaveScene()
    {
        //Pausing Dialogue
        if (DialogueManager.isConversationActive)
        {
            ConversationPositionStack.PushConversationPosition();
        }

        DialogueManager.displaySettings.defaultCanvas.enabled = false;

        //Loading and Unloading Scenes
        SceneManager.LoadScene("Save Scene", LoadSceneMode.Additive);
        SceneManager.UnloadScene("Mercenary Scene");
        //SceneManager.UnloadScene("Average Joe Scene");
        //SceneManager.UnloadScene("Corporate Scene");
        //SceneManager.UnloadScene("Drifter Scene");
    }
}
