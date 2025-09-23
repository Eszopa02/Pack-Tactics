using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;
using PixelCrushers;

public class ConversationManager : MonoBehaviour
{
    private string savedConversationState = null;
    private static ConversationManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveAndStopConversation()
    {
        if (DialogueManager.IsConversationActive)
        {
            //Get the save data for the current conversation playing
            savedConversationState = PersistentDataManager.GetSaveData();

            //Stop the active conversation
            DialogueManager.StopConversation();

            Debug.Log("Conversation state saved and stopped");
        }
    }

    public void ResumeConversation()
    {
        if (!string.IsNullOrEmpty(savedConversationState))
        {
            //Restore the state from the saved data
            PersistentDataManager.ApplySaveData(savedConversationState);

            Debug.Log("Conversation resumed from saved state");

            savedConversationState = null;
        }
    }
}
