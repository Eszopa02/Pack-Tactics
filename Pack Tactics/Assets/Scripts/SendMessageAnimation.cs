using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SendMessageAnimation : MonoBehaviour
{
    public GameObject PlayerMessage;

    public void OnButtonPress()
    {
        PlayerMessage.SetActive(true);
    }
}
