using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowManager : MonoBehaviour
{
    public GameObject[] plots;
    public int crowChance;
    public bool crowsActive;
    public static CrowManager instance;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int crowChanceCalc()
    {
        //set to be 50% or less
        crowChance = Random.Range(1, 50);
        return crowChance;
    }
    public bool determineCrow(int crowProb)
    {
        float num = Random.Range(1, 101);
        if (TimeManager.instance.currentDay == 1)
        {
            num = 0;
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
}
