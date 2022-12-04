using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    //Variables for counting the days
    public int currentDay = 1;
    public int previousDay = 0;
    public int dayLimit = 10;
    public bool gameEnd = false;
    public bool endingGood = false;
    public int scoreGoal = 50;
    public AudioSource musicPlayer;
    public AudioSource UIAudio;
    public AudioClip goodEndMusic;
    public AudioClip badEndMusic;
    public AudioClip selectSound;

    //variables for UI
    public TMP_Text currDay;
    public TMP_Text ending;
    public GameObject TimeUI;
    public GameObject StateUI;
    public GameObject Shop;
    SpriteRenderer sprite;
    public ShopManager shopSell;
    public Image win;
    public Image lose;
    public Image loseBG;
    public Image winBG;

    public NarrationManager narrate;

    public bool clickedYes = false;
    public bool clickedNo = false;
    public bool openWindow = false;

    public GameObject NextDay;
    public GameObject WeatherWindow;
    public GameObject shop;

    
    void Awake(){
        instance = this;
    }
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        TimeUI.SetActive(false);
        UIAudio.clip = selectSound;
        musicPlayer.loop = true;
        UIAudio.volume = 0.5f;
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
            if(shopSell.sellMgr.goodSold >= scoreGoal)
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
            winBG.enabled = true;
            loseBG.enabled = false;
            lose.enabled = false;
            swapSongEnd();
            Shop.SetActive(false);

        }
        else if(gameEnd && !endingGood)
        {
            StateUI.SetActive(true);
            win.enabled = false;
            lose.enabled = true;
            winBG.enabled = false;
            loseBG.enabled = true;
            swapSongEnd();
            Shop.SetActive(false);

        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        //bring up canvas to make sure user wants to move to next day
        if (narrate.narration == false)
        {
            TimeUI.SetActive(true);
            openWindow = true;
            NextDay.SetActive(false);
            WeatherWindow.SetActive(false);
            shop.SetActive(false);
        }
    }

    public void selectNo()
    {
        UIAudio.PlayOneShot(selectSound);
        TimeUI.SetActive(false);
        clickedNo = true;
        NextDay.SetActive(true);
        WeatherWindow.SetActive(true);
        shop.SetActive(true);
    }

    public void selectYes()
    {
        UIAudio.PlayOneShot(selectSound);
        clickedYes = true;
        TimeUI.SetActive(false);
        previousDay = currentDay;
        currentDay += 1;
        NextDay.SetActive(true);
        WeatherWindow.SetActive(true);
        shop.SetActive(true);

        int rainPercent = Weather.instance.rain();
        Weather.instance.ProbabilityCheck(rainPercent);
        Ticker.instance.DestroyTickerItem();
        Ticker.instance.AddTickerItem("Day " + currentDay);

        

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

    private void swapSongEnd()
    {
        if(endingGood && musicPlayer.clip != goodEndMusic)
        {
            musicPlayer.Stop();
            musicPlayer.clip = goodEndMusic;
            musicPlayer.Play();
        }
        else if(!endingGood && musicPlayer.clip != badEndMusic)
        {
            musicPlayer.Stop();
            musicPlayer.clip = badEndMusic;
            musicPlayer.Play();
        }

    }
}
