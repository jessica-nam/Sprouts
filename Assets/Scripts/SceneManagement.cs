using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void OpenShop(){
        SceneManager.LoadScene("Shop System");
    }

    public void BackToGame(){
        SceneManager.LoadScene("Game");
    }

    public void StartGame(){
        //load game from menu
        SceneManager.LoadScene("Game");
    }

    public void Menu(){
        // back to menu
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
