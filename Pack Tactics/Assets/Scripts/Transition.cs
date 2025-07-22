using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerSelect;
    public GameObject IntroScene;
    public GameObject SettingsScene;

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

    public void SettingsMenu()
    {
        IntroScene.SetActive(false);
        MainMenu.SetActive(false);
        PlayerSelect.SetActive(false);
        SettingsScene.SetActive(true);
    }

    public void ReturnToGame()
    {
        MainMenu.SetActive(false);
        PlayerSelect.SetActive(false);
        IntroScene.SetActive(true);
        SettingsScene.SetActive(false);
    }

}
