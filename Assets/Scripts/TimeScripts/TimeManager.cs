using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TimeManager : MonoBehaviour
{
    //Variables for counting the days
    public int currentDay = 1;
    public int previousDay = 0;
    public int dayLimit = 5;
    public bool gameEnd = false;
    public bool endingGood = false;
    public int quota = 7;

    //variables for UI
    public TMP_Text currDay;
    public TMP_Text ending;
    public GameObject TimeUI;
    public GameObject StateUI;
    SpriteRenderer sprite;
    public ShopManager shopSell;
    public Image win;
    public Image lose;
    


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        TimeUI.SetActive(false);
        
    }

    private void Update()
    {
        currDay.text = "Day: " + currentDay.ToString();
        if(currentDay > dayLimit)
        {
            gameEnd = true;
        }
        if(gameEnd == true)
        {
            if(shopSell.sellMgr.goodSold >= quota)
            {
                endingGood = true;
            }
            else
            {
                endingGood = false;
            }
        }
        if(gameEnd && endingGood)
        {
            StateUI.SetActive(true);
            win.enabled = true;
            lose.enabled = false;
        }
        else if(gameEnd && !endingGood)
        {
            StateUI.SetActive(true);
            win.enabled = false;
            lose.enabled = true;
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        //bring up canvas to make sure user wants to move to next day
        Plant.instance.turnOffAnims();
        TimeUI.SetActive(true);
    }

    public void selectNo()
    {
        Plant.instance.turnOnAnims();
        TimeUI.SetActive(false);
    }

    public void selectYes()
    {
        TimeUI.SetActive(false);
        previousDay = currentDay;
        currentDay += 1;
        Plant.instance.NewDayNewBabies();
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

    public void returnToMain()
    {
        SceneManager.LoadScene("Menu");
    }

}
