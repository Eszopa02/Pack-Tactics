using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAfterDelay : MonoBehaviour
{
    public GameObject NextScene;
    public float delayInSeconds = 5f;

    public void OnButtonPress()
    {
        StartCoroutine(ActivateAfterDelayCoroutine());
    }

    void ActiveObject()
    {
        NextScene.SetActive(true);
    }

    IEnumerator ActivateAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(delayInSeconds);
        NextScene.SetActive(true);
    }

}
