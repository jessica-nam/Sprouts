using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ticker : MonoBehaviour
{
    public static Ticker instance;
    public GameObject WeatherDisplay;

    private TextMeshProUGUI text;
    public TickerItem tickerItemPrefab;
    [Range(1f, 200f)]
    public float itemDuration = 3.0f;

    float width;
    float pixelsPerSecond;
    TickerItem currentItem;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        pixelsPerSecond = width / itemDuration;
        AddTickerItem(" Welcome to Sprouts!     ");
    }

    // Update is called once per frame
    void Update()
    {
        
            if (currentItem.GetXPosition <= -currentItem.GetWidth)
            {
                if (Weather.instance.isRaining)
                {

                    AddTickerItem("     There's a " + Weather.instance.rainPercent + "% chance of rain tomorrow! Time to take out those umbrellas.  If there is no rain, keep an eye out for Crows!     There's a " + CrowManager.instance.crowChance + "% chance they head up to sprouts farm!");
                   
                }
                else
                {
                    AddTickerItem("     It is a beautiful day on Sprouts Farm!     Tomorrow's forecast: sunshine, rainbows and babies!      There are Crows on the prowl!       Keep an eye on your crops farmers!  There is about a " + CrowManager.instance.crowChance + " % chance they head to sprouts farm!");


                }

            }else{
                int temp = 2;
            }
        
    }




    public void AddTickerItem(string message)
    {
        currentItem = Instantiate(tickerItemPrefab, transform);
        currentItem.Initialize(width, pixelsPerSecond, message);
    }
    public void DestroyTickerItem()
    {
        
    
        currentItem.Delete();
        

    }

    IEnumerator waitIdle()
    {
        yield return new WaitForSeconds(6f);


    }

}
