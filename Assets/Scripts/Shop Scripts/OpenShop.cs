using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField] Canvas ShopCanvas;
    private void OnMouseDown()
    {
        ShopCanvas.gameObject.SetActive(true);
    }
}
