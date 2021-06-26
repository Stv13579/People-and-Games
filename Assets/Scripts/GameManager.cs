using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    bool fadingIn = false;
    bool fadingOut = false;
    public bool gameStart = false;
    public bool gameOver = false;
    public bool gameEnding = false;
    public float fadeVar;
    public string[] textPrompts;
    public string[] postTextPrompts;
    int counter = 0;
    public GameObject textItem;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown("space") && !gameStart)
        {
            fadingIn = MoveTextAlong(textPrompts);
        }


        if (fadingIn)
        {
            FadeIn();
        }
        if (fadingOut)
        {
            FadeOut();
        }
        
        if (gameOver == true)
        {
            fadingOut = true;
            gameStart = false;
            gameOver = false;
            counter = 0;
        }


        if (Input.GetKeyDown("space") && gameEnding)
        {
            if(MoveTextAlong(postTextPrompts))
            {
                //change scene
            }
        }
    }

    //Returns true if text is all done, false if there is more text to cycle through
    bool MoveTextAlong(string[] texts)
    {
        
        if (counter > texts.Length - 1)
        {
            if (transform.childCount > 1)
            {
                Destroy(transform.GetChild(1).gameObject);
            }
            return true;
        }
        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        textItem.GetComponent<TextMeshProUGUI>().text = texts[counter];
        Instantiate(textItem, this.transform).transform.SetAsLastSibling();
        counter++;
        return false;
    }


    void FadeIn()
    {
        Color tmp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tmp.a -= fadeVar * Time.deltaTime;
        if( tmp.a <= 0)
        {
            tmp.a = 0;
            fadingIn = false;
            gameStart = true;
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
        
    }

    void FadeOut()
    {
        Color tmp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tmp.a += fadeVar * Time.deltaTime * 0.1f;
        if (tmp.a >= 1)
        {
            tmp.a = 1;
            fadingOut = false;
            gameEnding = true;
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
    }
}
