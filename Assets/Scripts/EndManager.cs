using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class EndManager : MonoBehaviour
{
    bool end = false;
    bool result = false;
    public float fadeVar;
    public string[] textPrompts;
    public string[] goodPrompts;
    public string[] badPrompts;
    int counter = 0;
    public GameObject textItem;
    public float score = 0;

    void Start()
    {
        score = 0;
        score = GameObject.Find("AnxTracker").GetComponent<AnxTrack>().anx;
    }


    void Update()
    {
        if (Input.GetKeyDown("space") && !result)
        {
            result = MoveTextAlong(textPrompts);
            if (result)
            {
                counter = 0;
            }
        }
        if (Input.GetKeyDown("space") && result && score < 10)
        {
            end = MoveTextAlong(goodPrompts);
        }
        if (Input.GetKeyDown("space") && result && score > 10)
        {
            end = MoveTextAlong(badPrompts);
        }
        if (end)
        {
            SceneManager.LoadScene(0);
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


    
}
