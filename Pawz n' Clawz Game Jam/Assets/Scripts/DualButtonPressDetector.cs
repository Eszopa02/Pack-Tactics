using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DualButtonPressDetector : MonoBehaviour
{
    public List<Button> allButtons;
    public List<Button> selectedButtons = new List<Button>();
    private const int maxSelected = 2;

    public Color normalColor = Color.white;
    public Color selectedColor = Color.grey;

    public void OnButtonClick(Button clickedButton)
    {
        if (selectedButtons.Contains(clickedButton))
        {
            DeselectButton(clickedButton);
        }
        else
        {
            SelectButton(clickedButton);
        }
    }

    private void SelectButton(Button button)
    {
        if (selectedButtons.Count < maxSelected)
        {
            selectedButtons.Add(button);

            if (button.image != null)
            {
                button.image.color = selectedColor;
            }

            Debug.Log("Button selected: " + button.gameObject.name);
        }
        else
        {
            Debug.Log("Maximum number of buttons already selected");
        }
    }

    private void DeselectButton(Button button)
    {
        selectedButtons.Remove(button);

        if(button.image != null)
        {
            button.image.color = normalColor;
        }
        Debug.Log("Button deselected: " + button.gameObject.name);
    }

    public List<Button> GetSelectedButton()
    {
        return selectedButtons;
    }
}
