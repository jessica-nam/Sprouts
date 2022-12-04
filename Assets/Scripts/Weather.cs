using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Weather : MonoBehaviour
{
    private TextMeshProUGUI rainChance;
    private int rainPercent;
    // Start is called before the first frame update
    void Start()
    {
        rainChance = GetComponent<TextMeshProUGUI>();
        rainPercent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rainChance.text = "There's a " + rainPercent.ToString() + "% chance of rain tomorrow! Time to take out those umbrellas.";
    }
}
