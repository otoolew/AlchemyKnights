using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ClickHandle : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData evd)
    {
        print("woot");
    }
}
