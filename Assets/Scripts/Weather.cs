using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weather : MonoBehaviour
{

    public static Weather instance;

    public string rainChance;
    public int rainPercent;
    public bool isRaining = false;

    public GameObject rainParticles;

    bool didNotRainDayBefore = false;


    void Awake(){
        instance = this;
    }

    void Start(){
        rainPercent = rain();

        ProbabilityCheck(rainPercent);
    }


    public bool ProbabilityCheck(int itemProbability)
    {
        float actualRain = Random.Range(0, 101);

        if(TimeManager.instance.currentDay == 1){
            actualRain = 0;
        }
        if (actualRain >= itemProbability){
            Debug.Log(actualRain);
            Debug.Log(itemProbability);
            isRaining = true;
            didNotRainDayBefore = false;
            
            return true;
        }else{
            Debug.Log(actualRain);
            Debug.Log(itemProbability);
            isRaining = false;
            didNotRainDayBefore = true;


            return false;
        }
          
    }

    public int rain()
    {
        int temp = 40;
        rainPercent = Random.Range(temp, 100); //60% chance to rain?
        if (didNotRainDayBefore){
            temp= 30;
        }else{
            temp = 40;
        }
        return rainPercent;

    }
}
