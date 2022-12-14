using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] GameObject blink;
    // Start is called before the first frame update
    void Start()
    {
        blink.SetActive(false);
    }

    void Update(){
        if(Weather.instance.isRaining){
            Invoke("EnableBlink", 0f);
            Invoke("DisableBlink", 0.1f);
        }
    }

    private void EnableBlink(){
        blink.SetActive(true);
    }

    private void DisableBlink(){
        blink.SetActive(false);
    }
}
