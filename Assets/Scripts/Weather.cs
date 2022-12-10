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
        int temp = 0;
        // move below float actualRain = Random.Range(temp, 101); if we want to give players more time before rain
        if (didNotRainDayBefore){
            temp= 70;
        }else{
            temp = 0;
        }

        float actualRain = Random.Range(temp, 101);

        

        if(TimeManager.instance.currentDay == 1){
            actualRain = 0;
        }
        if (actualRain >= itemProbability){
            isRaining = true;
            didNotRainDayBefore = false;
            
            return true;
        }else{
            isRaining = false;
            didNotRainDayBefore = true;


            return false;
        }
          
    }

    public int rain()
    {
        rainPercent = Random.Range(60, 100); 
        
        return rainPercent;

    }
}
