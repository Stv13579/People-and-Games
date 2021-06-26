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
    public float fadeVar;
    public string[] textPrompts;
    int counter = 0;
    public GameObject textItem;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown("space") && !gameStart)
        {
            MoveTextAlong();
        }

        if (fadingIn)
        {
            FadeIn();
        }
        if (fadingOut)
        {
            FadeOut();
        }
        

    }

    void MoveTextAlong()
    {
        
        if (counter > textPrompts.Length - 1)
        {
            fadingIn = true;
            gameStart = true;
            if (transform.childCount > 1)
            {
                Destroy(transform.GetChild(1).gameObject);
            }
            return;
        }
        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(1).gameObject);
        }
        textItem.GetComponent<TextMeshProUGUI>().text = textPrompts[counter];
        Instantiate(textItem, this.transform).transform.SetAsLastSibling();
        counter++;
    }


    void FadeIn()
    {
        Color tmp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tmp.a -= fadeVar * Time.deltaTime;
        if( tmp.a <= 0)
        {
            tmp.a = 0;
            fadingIn = false;
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
        
    }

    void FadeOut()
    {
        Color tmp = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        tmp.a += fadeVar * Time.deltaTime;
        if (tmp.a >= 1)
        {
            tmp.a = 1;
            fadingOut = false;
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = tmp;
    }
}
