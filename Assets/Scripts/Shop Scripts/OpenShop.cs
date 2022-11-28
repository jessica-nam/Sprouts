using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenShop : MonoBehaviour
{
    [SerializeField] Canvas ShopCanvas;
    [SerializeField] private GameObject nextDay;
    [SerializeField] private AudioSource UIsfx;
    [SerializeField] private AudioClip shopSelect;


    private void OnMouseDown()
    {
        ShopCanvas.gameObject.SetActive(true);
        nextDay.SetActive(false);
        UIsfx.PlayOneShot(shopSelect);
    }
}
