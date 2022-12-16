using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipsController : MonoBehaviour
{
    public GameObject ToolTipsUI;
    public CanvasGroup fade;
    public CanvasGroup fade2;
    bool fadeOut = false;
    bool fadeOut2 = false;
    bool check = false;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            if (fade.alpha == 1)
            {
                fade.alpha -= Time.deltaTime;
                if (fade.alpha <= 0)
                {
                    fadeOut = false;
                }
            }
        }

        if (fadeOut2)
        {
            if (fade2.alpha == 1)
            {
                fade2.alpha -= Time.deltaTime;
                if (fade2.alpha <= 0)
                {
                    fadeOut2 = false;
                }
            }
        }

        if(!fadeOut && !fadeOut2 && check)
        {
            ToolTipsUI.SetActive(false);
        }
    }

     public void fadeToolOne()
    {
        fadeOut = true;
        check = true;
        ToolTipsUI.SetActive(false);
    }
     public void fadeToolTwo()
    {
        fadeOut2 = true;
        check = true;
        ToolTipsUI.SetActive(false);
    }
}
