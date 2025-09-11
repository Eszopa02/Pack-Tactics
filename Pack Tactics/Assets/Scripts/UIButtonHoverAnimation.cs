using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Animator buttonAnimator;

    void Start()
    {
        if (buttonAnimator != null)
        {
            buttonAnimator.Play("Idle");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonAnimator != null)
        {
            buttonAnimator.SetTrigger("HoverOn");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonAnimator != null)
        {
            buttonAnimator.SetTrigger("HoverOff");
        }
    }
}

