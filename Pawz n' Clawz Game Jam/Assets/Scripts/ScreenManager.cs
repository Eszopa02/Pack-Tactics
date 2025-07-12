using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public Button toggleButton;
    private bool isFullScreen;

    void Start()
    {
        isFullScreen = PlayerPrefs.GetInt("FullScreen", 1) == 1;

        SetScreenMode(isFullScreen);

        toggleButton.onClick.AddListener(ToggleFullScreen);

    }

    void SetScreenMode(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;

        if (!fullScreen)
        {
            Screen.SetResolution(1280, 720, false);
        }
    }

    public void ToggleFullScreen()
    {
        isFullScreen = !isFullScreen;
        SetScreenMode(isFullScreen);

        PlayerPrefs.SetInt("Fullscreen", isFullScreen ? 1 : 0);
        PlayerPrefs.Save();
    }
    
}
