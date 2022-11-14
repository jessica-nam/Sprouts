using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;



public class test : MonoBehaviour
{
    private bool inProgress;
    private DateTime TimerStart;
    private DateTime TimerEnd;

    private Coroutine lastTimer;
    private Coroutine lastDisplay;

    public Vector3Int position;

    [Header("Production time")]
    public int Days;
    public int Hours;
    public int Minutes;
    public int Seconds;

    [Header("UI")]
    [SerializeField] private GameObject window;
    [SerializeField] private TextMeshProUGUI startTimeText;
    [SerializeField] private TextMeshProUGUI endTimeText;
    [SerializeField] private GameObject timeLeftObject;
    [SerializeField] private TextMeshProUGUI timeLeftText;
    [SerializeField] private Slider timeLeftSlider;
    [SerializeField] private Button skipButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile done;

    #region Unity methods

    private void Start(){
        startButton.onClick.AddListener(StartTimer);
        skipButton.onClick.AddListener(Skip);
    }

    #endregion

    #region UI methods

    private void InitializeWindow(){
        if(inProgress){
            startTimeText.text = "Start Time: " + TimerStart;
            endTimeText.text = "End Time: " + TimerEnd;

            timeLeftObject.SetActive(true);
            window.SetActive(true);
            lastDisplay = StartCoroutine(DisplayTime());

            startButton.gameObject.SetActive(false);
            skipButton.gameObject.SetActive(true);
        }else{
            startTimeText.text = "";
            endTimeText.text = "";
        }
        
    }

    private IEnumerator DisplayTime(){
        DateTime start = DateTime.Now;
        TimeSpan timeLeft = TimerEnd - start;
        double totalSecondsLeft = timeLeft.TotalSeconds;
        double totalSeconds = (TimerEnd - TimerStart).TotalSeconds;

        position = Plant.instance.currentSprout;

        string text;
        while(window.activeSelf && timeLeftObject.activeSelf){
            text = "";
            timeLeftSlider.value = 1- Convert.ToSingle((TimerEnd - DateTime.Now).TotalSeconds/totalSeconds);
            if(totalSecondsLeft > 1){
                if(timeLeft.Days != 0){
                    text += timeLeft.Days + "d ";
                    text += timeLeft.Hours + "h";
                    yield return new WaitForSeconds(timeLeft.Minutes * 60);
                }else if(timeLeft.Hours != 0){
                    text += timeLeft.Hours + "h ";
                    text += timeLeft.Minutes + "m";
                    yield return new WaitForSeconds(timeLeft.Seconds);
                }else if(timeLeft.Minutes != 0){
                    TimeSpan ts = TimeSpan.FromSeconds(totalSecondsLeft);
                    text += ts.Minutes + "m ";
                    text += ts.Seconds + "s";
                }else{
                    text += Mathf.FloorToInt((float) totalSecondsLeft) + "s";
                }

                timeLeftText.text = text;
                totalSecondsLeft -= Time.deltaTime;
                yield return null;
            
            }
            else{
                timeLeftText.text = "Finished";
                skipButton.gameObject.SetActive(false);
                inProgress = false;
                Debug.Log(position);
                interactableMap.SetTile(position, done);
                break;
            }
        }
        yield return null;
    }


    #endregion

    #region Timed event

    private void StartTimer(){
        TimerStart = DateTime.Now;
        TimeSpan time = new TimeSpan(Days, Hours, Minutes, Seconds);
        TimerEnd = TimerStart.Add(time);
        inProgress = true;

        lastTimer = StartCoroutine(Timer());

        InitializeWindow();
    }

    private IEnumerator Timer(){
        DateTime start = DateTime.Now;
        double secondsToFinished = (TimerEnd - start).TotalSeconds;
        yield return new WaitForSeconds(Convert.ToSingle(secondsToFinished));

        inProgress = false;
        Debug.Log("Finished");
    }

    private void Skip(){
        TimerEnd = DateTime.Now;
        inProgress = false;

        position = Plant.instance.currentSprout;
        interactableMap.SetTile(position, done);
        
        StopCoroutine(lastTimer);

        timeLeftText.text = "Finished";
        timeLeftSlider.value = 1;

        StopCoroutine(lastDisplay);
        skipButton.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
    }
    #endregion




}
