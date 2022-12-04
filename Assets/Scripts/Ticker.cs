using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ticker : MonoBehaviour
{
    public static Ticker instance;

    private TextMeshProUGUI text;
    public TickerItem tickerItemPrefab;
    [Range(1f, 200f)]
    public float itemDuration = 3.0f;
    public string[] fillerItems;

    float width;
    float pixelsPerSecond;
    TickerItem currentItem;

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        width = GetComponent<RectTransform>().rect.width;
        pixelsPerSecond = width / itemDuration;
        AddTickerItem(fillerItems[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentItem.GetXPosition <= -currentItem.GetWidth + 10f)
        {
            AddTickerItem(fillerItems[Random.Range(0, fillerItems.Length)]);
        }
    }


    public void AddTickerItem(string message)
    {
        currentItem = Instantiate(tickerItemPrefab, transform);
        currentItem.Initialize(width, pixelsPerSecond, message);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);

    }

}
