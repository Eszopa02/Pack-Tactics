using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers;

public class ManualSaveLoad : MonoBehaviour
{
    public void SaveGame()
    {
        SaveSystem.SaveToSlot(1);
        Debug.Log("Saved Game");
    }

    public void LoadGame()
    {
        SaveSystem.LoadFromSlot(1);

    }
}
