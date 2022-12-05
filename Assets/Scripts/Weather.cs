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


    void Awake(){
        instance = this;
    }

    void Start(){
        rainPercent = rain();

        ProbabilityCheck(rainPercent);
    }


    public bool ProbabilityCheck(int itemProbability)
    {
        float rnd = Random.Range(1, 101);

        if(TimeManager.instance.currentDay == 1){
            rnd = 0;
        }
        if (rnd <= itemProbability){
            isRaining = true;
            
            return true;
        }else{
            isRaining = false;


            return false;
        }
          
    }

    public int rain()
    {
        rainPercent = Random.Range(10, 60); //60% chance to rain?

        return rainPercent;

    }
}
