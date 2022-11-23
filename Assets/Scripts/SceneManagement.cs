using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    GameObject SavedObjs;
    SaveObject Instance;

    private void Awake()
    {
        SavedObjs = SaveObject.savedObjs;
        Instance = SaveObject.instance;
    }

    public void OpenShop(){
        SceneManager.LoadScene("Shop System");
    }

    public void BackToGame(){
        SceneManager.LoadScene("Game");
    }

    public void PlayGame(){
        //load game
        SceneManager.LoadScene("Game");
        this.gameObject.SetActive(true); // activates persistent objs (first run of game) -- first need to create an instance of persistent objs before being able to access them
        if (Instance != null) // if not first time game run, like if player goes from menu -> game -> menu 
            Instance.gameObject.SetActive(true); 
    }

    public void Menu(){
        // back to menu
        SceneManager.LoadScene("Menu");
        SavedObjs.gameObject.SetActive(false); // deactivate persistent objs
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
