using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopTemplate : MonoBehaviour
{
    public TMP_Text titleTxt;
    public TMP_Text titleTxtShadow;
    public TMP_Text descriptionTxt;
    public TMP_Text costTxt;
    public Image image;
    public TMP_Text attributesTxt;

    public void Reset()
    {
        // titleTxt;
        // descriptionTxt;
        costTxt.text = string.Empty;
        image.sprite = null;
        attributesTxt.text = string.Empty;
    }
}
