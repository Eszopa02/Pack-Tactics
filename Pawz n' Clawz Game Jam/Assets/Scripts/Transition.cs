using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayerSelect;

    public void OnButtonPress()
    {
        MainMenu.SetActive(false);
        PlayerSelect.SetActive(true);
    }
}
