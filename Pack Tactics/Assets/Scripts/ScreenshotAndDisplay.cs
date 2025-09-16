using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotAndDisplay : MonoBehaviour
{
    public Button button1; // Button to take a screenshot
    public List<Button> imageButtons; // List of buttons whose images will be updated

    private Texture2D lastScreenshot; // Stores the last taken screenshot

    void Start()
    {
        // Assign button click listeners
        button1.onClick.AddListener(TakeScreenshotImmediate);

        // Ensure imageButtons list is not null
        if (imageButtons == null)
        {
            imageButtons = new List<Button>();
        }

        // Assign click listeners for imageButtons (Button 2 and 3)
        for (int i = 0; i < imageButtons.Count; i++)
        {
            int index = i; // Capture index for closure
            imageButtons[index].onClick.AddListener(() => UpdateButtonImage(index));
        }
    }

    // Take a screenshot immediately without waiting for end of frame
    void TakeScreenshotImmediate()
    {
        // Create a new Texture2D to store the screenshot
        lastScreenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        lastScreenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        lastScreenshot.Apply();

        Debug.Log("Screenshot taken immediately.");
    }

    // Update the image of a specified button with the last screenshot
    void UpdateButtonImage(int buttonIndex)
    {
        if (lastScreenshot != null && buttonIndex < imageButtons.Count)
        {
            Sprite sprite = Sprite.Create(lastScreenshot, new Rect(0, 0, lastScreenshot.width, lastScreenshot.height), new Vector2(0.5f, 0.5f));
            imageButtons[buttonIndex].GetComponent<Image>().sprite = sprite;
            Debug.Log($"Button {buttonIndex + 2} image updated with screenshot.");
        }
        else if (lastScreenshot == null)
        {
            Debug.LogWarning("No screenshot available to update image.");
        }
        else
        {
            Debug.LogError($"Invalid button index: {buttonIndex}");
        }
    }
}
