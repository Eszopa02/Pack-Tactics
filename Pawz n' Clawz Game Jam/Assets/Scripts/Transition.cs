using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerSelect;
    public GameObject IntroScene;

    public void OnButtonPress()
    {
        MainMenu.SetActive(false);
        PlayerSelect.SetActive(true);
    }

    public void ReturnToMenu()
    {
        IntroScene.SetActive(false);
        MainMenu.SetActive(true);
    }
}
