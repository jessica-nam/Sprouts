using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeManager : MonoBehaviour
{
    public int currentDay = 1;
    public int previousDay = 0;
    public int dayLimit = 7;
    public bool gameEnd = false;
    public TMP_Text currDay;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
       
    }

    private void Update()
    {
        currDay.text = "Day: " + currentDay.ToString();
        if(currentDay > dayLimit)
        {
            gameEnd = true;
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        //bring up canvas to make sure user wants to move to next day

        //test click is working properly
        previousDay = currentDay;
        currentDay += 1;

    }

    private void OnMouseOver()
    {
        //change sign color when hovered over.
        sprite.color = new Color(255, 0, 0, 1);
    }
    private void OnMouseExit()
    {
        sprite.color = new Color(255, 255, 255, 1);
    }
}
