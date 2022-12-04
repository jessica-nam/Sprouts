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

    // Start is called before the first frame update

    void Awake(){
        instance = this;
    }

    void Start(){
        rainPercent = rain();
        Debug.Log("Rain Percent: ");
        Debug.Log(rainPercent);
        ProbabilityCheck(rainPercent);
    }


    //this is the basic Probability function that will take the item chance is 30% and then check if you'll get or not
    public bool ProbabilityCheck(int itemProbability)
    {
        float rnd = Random.Range(1, 101);
        Debug.Log("Random chance ");
        Debug.Log(rnd);
        if(TimeManager.instance.currentDay == 1){
            rnd = 0;
        }
        if (rnd <= itemProbability){
            isRaining = true;
            Debug.Log("Is rain is truw for tmrw");
            //rainParticles.SetActive(false);
            
            return true;
        }else{
            isRaining = false;
            Debug.Log("Is rain is false");
            //rainParticles.SetActive(true);

            return false;
        }
            
    
    }

    public int rain()
    {
        rainPercent = Random.Range(1, 101);
        return rainPercent;

    }
}
