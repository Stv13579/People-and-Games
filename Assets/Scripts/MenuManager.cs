using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject initScreen; 
    public GameObject howToPlayScreen; 
    
    public void howToPlay()
    {
        initScreen.SetActive(false);
        howToPlayScreen.SetActive(true);
    }

    public void backToMenu()
    {
        initScreen.SetActive(true);
        howToPlayScreen.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

}
