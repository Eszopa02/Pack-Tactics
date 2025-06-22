using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrewMemberSubmitButton : MonoBehaviour
{
    public Button[] selectionButtons = new Button[4];

    public Button triggerButton;

    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    private List<Button> selectedButtons = new List<Button>();

    void Start()
    {
        for (int i = 0; i < selectionButtons.Length; i++)
        {
            int buttonIndex = i; 
            selectionButtons[i].onClick.AddListener(() => OnSelectionButtonClick(selectionButtons[buttonIndex]));
        }

        triggerButton.onClick.AddListener(OnTriggerButtonClick);
    }

    void OnSelectionButtonClick(Button clickedButton)
    {
        if (selectedButtons.Contains(clickedButton))
        {
            selectedButtons.Remove(clickedButton);
        }
        else
        {
            if (selectedButtons.Count < 2)
            {
                selectedButtons.Add(clickedButton);
            }
        }

        Debug.Log("Selected buttons count: " + selectedButtons.Count);
    }

    void OnTriggerButtonClick()
    {
        if (selectedButtons.Count == 2)
        {
            if (objectToDeactivate != null)
            {
                objectToDeactivate.SetActive(false);
                Debug.Log(objectToDeactivate.name + " deactivated.");
            }

            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
                Debug.Log(objectToActivate.name + " activated.");
            }
        }
        else
        {
            Debug.Log("Please select exactly two buttons before pressing the trigger button.");
        }
    }
}
