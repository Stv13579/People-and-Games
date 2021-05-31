using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public int timer = 1000;
    public GameObject bubble;
    private GameObject currentBubble;
    private GameObject currentBubbleCanvas;
    private GameObject currentBubbleText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1;
        if (timer <= 0)
        {
            timer = 1000;
            currentBubble = Instantiate(bubble);
            currentBubbleCanvas = currentBubble.transform.GetChild(0).gameObject;
            currentBubbleText = currentBubbleCanvas.transform.GetChild(0).gameObject;
            currentBubbleText.GetComponent<UnityEngine.UI.Text>().text = "test";
        }
    }
}
