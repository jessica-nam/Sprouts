using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMgr : MonoBehaviour
{
    public int score;
    public TMP_Text scoreUI;

    private void Start()
    {
        UpdateScoreUI();
        score = 0;
    }

    public void UpdateScoreUI()
    {
        scoreUI.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score = score + amount;
        UpdateScoreUI();
    }
}
