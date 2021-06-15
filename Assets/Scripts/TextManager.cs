using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public float timer = 1000;
    public float timerTotal;

    public string[] texts;


    public GameObject bubble;
    private GameObject currentBubble;
    private GameObject currentBubbleCanvas;
    private GameObject currentBubbleText;


    public int score = 0;
    
    void Start()
    {
        timer = timerTotal;
    }

   
    void Update()
    {
        timer -= Time.deltaTime * 10;
        if (timer <= 0)
        {
            timer = timerTotal;
            currentBubble = Instantiate(bubble, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, -0.5f, 10.0f)), Quaternion.identity); //Spawning using screen space so they always spawn below the screen and rise up
            currentBubbleCanvas = currentBubble.transform.GetChild(0).gameObject;
            currentBubbleText = currentBubbleCanvas.transform.GetChild(0).gameObject;
            int index = Random.Range(0, texts.Length);
            currentBubbleText.GetComponent<UnityEngine.UI.Text>().text = texts[index];
            currentBubble.tag = "Anxiety";

        }
    }
}
