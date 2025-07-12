using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeChanger : MonoBehaviour
{
    public Text subtitleText;
    public Text nPCText;
    public Text responseText;

    public int smallSize = 20;

    public int mediumSize = 25;

    public int LargeSize = 30;

    public void SmallFontSize()
    {
        if (subtitleText != null) subtitleText.fontSize = smallSize;
        if (nPCText != null) nPCText.fontSize = smallSize;
        if (responseText != null) responseText.fontSize = smallSize;
    }

    public void MediumFontSize()
    {
        if (subtitleText != null) subtitleText.fontSize = mediumSize;
        if (nPCText != null) subtitleText.fontSize = mediumSize;
        if (responseText != null) responseText.fontSize = mediumSize;
    }

    public void LargeFontSize()
    {
        if (subtitleText != null) subtitleText.fontSize = LargeSize;
        if (nPCText != null) subtitleText.fontSize = LargeSize;
        if (responseText != null) subtitleText.fontSize = LargeSize;
    }
 
}
