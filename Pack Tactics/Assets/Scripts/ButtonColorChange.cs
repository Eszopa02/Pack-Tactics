using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonColorChange : MonoBehaviour
{
    private Image image;
    private Image buttonImage;
    private Color originalColor;
    private bool isColorChanged = false;

    
    private static List<ButtonColorChange> coloredButtons = new List<ButtonColorChange>();
    private const int MAX_COLORED_BUTTONS = 2;

    void Awake()
    {
        image = GetComponent<Image>();
        originalColor = image.color; 
    }

    public void OnButtonClick()
    {
        if (isColorChanged)
        {
            image.color = originalColor;
            isColorChanged = false;
            coloredButtons.Remove(this);
        }
        else
        {
            if (coloredButtons.Count < MAX_COLORED_BUTTONS)
            {
                image.color = Color.grey; 
                isColorChanged = true;
                coloredButtons.Add(this);
            }
        }
    }
}
