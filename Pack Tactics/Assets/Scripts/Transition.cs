using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerSelect;
    public GameObject IntroScene;
    public GameObject SettingsScene;

    public GameObject Menu2;
    public GameObject SettingsScreen2;

    

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
        MainMenu.SetActive(false);
        PlayerSelect.SetActive(true);
        IntroScene.SetActive(false);
        SettingsScene.SetActive(false);
    }

}
