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
    private int scoreGoal = 150;
    public AudioSource musicPlayer;
    public AudioSource UIAudio;
    public AudioClip goodEndMusic;
    public AudioClip badEndMusic;
    public AudioClip selectSound;

    //variables for UI
    public TMP_Text currDay;
    public TMP_Text ending;
    public GameObject UICanvas;
    public GameObject WeatherUI;
    public GameObject GameViewUI;
    public GameObject TimeUI;
    public GameObject StateUI;
    public GameObject Shop;
    SpriteRenderer sprite;
    public ShopManager shopSell;
    public GameObject winScreen;
    public GameObject loseScreen;
    private ScoreMgr scoreMgr;

    public NarrationManager narrate;

    public bool clickedYes = false;
    public bool clickedNo = false;
    public bool openWindow = false;

    public GameObject NextDay;
    public GameObject WeatherWindow;
    public GameObject shop;
    public GameObject rainParticles;

    
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

        scoreMgr = UICanvas.gameObject.transform.Find("Score UI").gameObject.GetComponent<ScoreMgr>();
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
            WeatherUI.SetActive(false);
            GameViewUI.SetActive(false);
            UICanvas.SetActive(false);
            StateUI.SetActive(true);
            Shop.SetActive(false);
            swapSongEnd();
            
            if (scoreMgr.score >= scoreGoal)
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
            winScreen.SetActive(true);
            loseScreen.SetActive(false);
        }
        else if(gameEnd && !endingGood)
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        //bring up canvas to make sure user wants to move to next day
        if (narrate.narration == false)
        {
            UICanvas.SetActive(false);
            TimeUI.SetActive(true);
            openWindow = true;
            NextDay.SetActive(false);
            WeatherWindow.SetActive(false);
            shop.SetActive(false);
        }
    }

    public void selectNo()
    {
        UICanvas.gameObject.SetActive(true);
        UIAudio.PlayOneShot(selectSound);
        TimeUI.SetActive(false);
        clickedNo = true;
        NextDay.SetActive(true);
        WeatherWindow.SetActive(true);
        shop.SetActive(true);
    }

    public void selectYes()
    {
        if(Weather.instance.isRaining){
            rainParticles.SetActive(true);
        }else{
            rainParticles.SetActive(false);
        }

        UICanvas.gameObject.SetActive(true);
        UIAudio.PlayOneShot(selectSound);
        clickedYes = true;
        TimeUI.SetActive(false);
        previousDay = currentDay;
        currentDay += 1;
        NextDay.SetActive(true);
        WeatherWindow.SetActive(true);
        shop.SetActive(true);

        Ticker.instance.DestroyTickerItem();
        Ticker.instance.AddTickerItem("Day " + currentDay + "     ");

        int rainPercent = Weather.instance.rain();
        Weather.instance.ProbabilityCheck(rainPercent);

        

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
