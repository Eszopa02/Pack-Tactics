using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSelection : MonoBehaviour
{
    public GameObject PlayerBackgroundImage;
    public GameObject NextBackgroundImage;

    public void WhenButtonClicked()
    {
        if (PlayerBackgroundImage.activeInHierarchy == true)
        {
            PlayerBackgroundImage.SetActive(false);
            NextBackgroundImage.SetActive(true);


        }
        

    }
}
