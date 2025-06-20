using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class DatabaseSwitcher : MonoBehaviour
{
    public DialogueDatabase databaseToLoad;
    public DialogueDatabase databaseOneToUnload;
    public DialogueDatabase databaseTwoToUnload;

    public void OnButtonClick()
    {
        if (databaseToLoad != null)
        {
            DialogueManager.AddDatabase(databaseToLoad);
        }
        else
        {
            DialogueManager.RemoveDatabase(databaseOneToUnload);
            DialogueManager.RemoveDatabase(databaseTwoToUnload);
        }
    }

        
}
