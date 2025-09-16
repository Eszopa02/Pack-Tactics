using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScreenDelay : MonoBehaviour
{
    public GameObject objectToDeactivate; 
    public GameObject objectToActivate;   
    public float delayTime = 5.0f;       

    
    public void StartSwitching()
    {
        StartCoroutine(SwitchObjectsWithDelay());
    }

    private IEnumerator SwitchObjectsWithDelay()
    {
        
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }

        
        yield return new WaitForSeconds(delayTime);

        
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
