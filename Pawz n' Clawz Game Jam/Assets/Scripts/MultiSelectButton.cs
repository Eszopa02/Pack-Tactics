using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiSelectButton : MonoBehaviour
{
    public bool isButtonSelected = false;
    
    

    public void OnButtonClick()
    {
        isButtonSelected = !isButtonSelected;

    }

    
}
