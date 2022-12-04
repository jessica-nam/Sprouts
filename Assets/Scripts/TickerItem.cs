using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TickerItem : MonoBehaviour
{
    public static TickerItem instance;

    float tickerWidth;
    float pixelsPerSecond;
    RectTransform rt;

    public bool destroyed = false;

    void Awake()
    {
        instance = this;
    }


    public float GetXPosition{get{return rt.anchoredPosition.x;}}
    public float GetWidth{get{return rt.rect.width;}}

    public void Initialize(float tickerWidth, float pixelsPerSecond, string message){
        this.tickerWidth = tickerWidth;
        this.pixelsPerSecond = pixelsPerSecond;
        rt = GetComponent<RectTransform>();
        GetComponent<TextMeshProUGUI>().text = message;
        
    }

    // Update is called once per frame
    void Update()
    {
        rt.position += Vector3.left * pixelsPerSecond * Time.deltaTime;
        if(GetXPosition <= 0 - tickerWidth - GetWidth){
            destroyed = true;
            Destroy(gameObject);
        }else{
            destroyed = false;
        }
    }
}
