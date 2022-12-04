using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarecrowButtons : MonoBehaviour
{
    public GameObject scarecrowicon1;
    public GameObject scarecrowicon2;
    public GameObject scarecrowicon3;

    public void ShowScarecrows1(){
        scarecrowicon1.SetActive(true);
    }
    public void ShowScarecrows2(){
        scarecrowicon2.SetActive(true);
    }
    public void ShowScarecrows3(){
        scarecrowicon3.SetActive(true);
    }
}
