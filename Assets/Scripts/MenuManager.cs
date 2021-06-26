using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject initScreen; 
    public GameObject howToPlayScreen; 
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

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

}
