using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject attributesGO;

    public void OnPointerEnter(PointerEventData eventData)
    {
        attributesGO.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        attributesGO.SetActive(false);
    }
}
