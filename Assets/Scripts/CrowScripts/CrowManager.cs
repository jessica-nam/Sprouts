using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CrowManager : MonoBehaviour
{

    public int crowChance;
    public bool crowsActive;
    public static CrowManager instance;
    public PlotManager[] managers;
    public AudioSource crowSFX;
    public AudioClip crowNoise;



    void Awake()
    {
        instance = this;
       
    }
    // Start is called before the first frame update
    void Start()
    {
       
        crowChance = crowChanceCalc();
        determineCrow(crowChance);
    }

    public void ProceedDay()
    {
        
        crowChance = crowChanceCalc();
        determineCrow(crowChance);
        testPlots();

    }
    // Update is called once per frame

    public int crowChanceCalc()
    {
        //set to be 50% or less
        crowChance = Random.Range(10, 101);
        return crowChance;
    }
    public bool determineCrow(int crowProb)
    {
        float num = Random.Range(1, 101);
        if (TimeManager.instance.currentDay == 1)
        {
            num = 150;
        }
        if (num <= crowProb)
        {
            crowsActive = true;
            return true;
        }
        else
        {
            crowsActive = false;
            return false;
        }
    }

    public void testPlots()
    {
        if (!crowsActive)
            return;
        if (Weather.instance.isRaining)
            return;
        crowSFX.PlayOneShot(crowNoise);
        foreach (PlotManager plots in managers)
        {
            if(!plots.scareCrowOut)
            {
                plots.gameObject.SetActive(false);
                plots.dead.SetActive(true);
            }
            plots.scareCrowOut = false;
        }
    }
}
