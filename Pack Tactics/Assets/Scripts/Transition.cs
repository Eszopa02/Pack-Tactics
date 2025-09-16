using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class Transition : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerSelect;
    public GameObject IntroScene;
    public GameObject SettingsScene;

    public GameObject Menu2;
    public GameObject SettingsScreen2;

    public GameObject SaveScreen;
    public Canvas DialogueScene;

    //void Start()
    //{
        //if (DialogueManager.instance != null && DialogueManager.instance.displaySettings.defaultCanvas != null)
        //{/
            //DialogueScene = DialogueManager.instance.displaySettings.defaultCanvas;
        //}
    //}


    public void Save()
    {
        if (DialogueManager.isConversationActive)
        {
            ConversationPositionStack.PushConversationPosition();
            //DialogueManager.StopConversation();
        }
        
        DialogueManager.displaySettings.defaultCanvas.enabled = false;

        SaveScreen.SetActive(true);
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        PlayerSelect.SetActive(true);
        IntroScene.SetActive(false);
        SettingsScene.SetActive(false);
    }

    public void ReturnToMenu()
    {
        IntroScene.SetActive(false);
        PlayerSelect.SetActive(false);
        SettingsScene.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void MainMenu2()
    {
        IntroScene.SetActive(false);
        PlayerSelect.SetActive(false);
        SettingsScene.SetActive(false);
        Menu2.SetActive(true);
    }

    public void StartGame2()
    {
        IntroScene.SetActive(true);
        PlayerSelect.SetActive(false);
        SettingsScene.SetActive(false);
        Menu2.SetActive(false);
    }

    public void Settings2()
    {
        IntroScene.SetActive(false);
        MainMenu.SetActive(false);
        PlayerSelect.SetActive(false);
        SettingsScreen2.SetActive(true);
    }

    public void SettingsMenu()
    {
        IntroScene.SetActive(false);
        MainMenu.SetActive(false);
        PlayerSelect.SetActive(false);
        SettingsScene.SetActive(true);
    }

    public void ReturnToGame()
    {
        //MainMenu.SetActive(false);
        PlayerSelect.SetActive(true);
        IntroScene.SetActive(false);
        //SettingsScene.SetActive(false);
        SaveScreen.SetActive(false);
    }

    public void ExitSave()
    {
        SaveScreen.SetActive(false);

        DialogueManager.displaySettings.defaultCanvas.enabled = true;
        //DialogueManager.StartConversation("New Conversation 1");
        ConversationPositionStack.PopConversationPosition();
    }


}
