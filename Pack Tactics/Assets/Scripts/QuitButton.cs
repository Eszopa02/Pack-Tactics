using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game closed.");
    }
}
