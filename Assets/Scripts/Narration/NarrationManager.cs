using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum narState
{
    closedLetter = 0,
    openedLetter = 1
}
public class NarrationManager : MonoBehaviour
{

    //Fade letter in and out
    public CanvasGroup fade;
    bool fadeIn = false;
    public bool narration = true;

    //traversal variables
    int currentState = 0;

    //UI variables
    public GameObject NarationUI;
    public GameObject shop;
    public GameObject shopUI;
    public Image closedL;
    public Image openL;
    public Image background;
    public Image paper;
    public TMP_Text letter;
    private void Awake()
    {
        NarationUI.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        //enable the UI when game starts
        NarationUI.SetActive(true);
        closedL.enabled = true;
        background.enabled = true;
        openL.enabled = false;


        //endable it but make its alpha zero for fade in
        fade.interactable = true;
        fade.enabled = true;
        fade.alpha = 0;
        paper.enabled = true;
        letter.enabled = true;


        shop.SetActive(false);
        shopUI.SetActive(false);
        currentState = (int)narState.closedLetter;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn)
        {
            if(fade.alpha < 1)
            {
                fade.alpha += Time.deltaTime;
                if(fade.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
    }

    void openLetter()
    {
        //hide letter open letter and then do the fade in
        closedL.enabled = false;
        openL.enabled = true;
        fadeIn = true;
        currentState = (int)narState.openedLetter;

    }
    void beginGame()
    {
        NarationUI.SetActive(false);
        narration = false;
        shop.SetActive(true);
        shopUI.SetActive(true);
    }
    public void pressedButton()
    {
        if(currentState == (int)narState.closedLetter)
            openLetter();
        
        else if(currentState == (int)narState.openedLetter)
            beginGame();
       
    }
}
