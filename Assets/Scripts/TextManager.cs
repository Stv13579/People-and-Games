using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public float timer;
    public float timerTotal;

    public string[] texts;


    public GameObject bubble;
    private GameObject currentBubble;
    private GameObject currentBubbleCanvas;
    private GameObject currentBubbleText;

    public GameObject interviewer;

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
            //If there is a question to be answered spawn answers and false answers
            if (interviewer.GetComponent<InterviewerScript>().questions.Length > 0)
            {
                int choice = Random.Range(0, 10);
                if (choice == 0)
                {
                    makeAnswer();
                }
                if (choice > 0 && choice < 6)
                {
                    makeBadAnswer();
                }
                if (choice > 5)
                {
                    makeBadThought();
                }
            }
            //Otherwise just spawn bad thoughts
            else
            {
                makeBadThought();
            }
        }
    }

    void makeBadThought()
    {
        timer = timerTotal;
        currentBubble = Instantiate(bubble, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, -0.5f, 10.0f)), Quaternion.identity); //Spawning using screen space so they always spawn below the screen and rise up
        currentBubbleCanvas = currentBubble.transform.GetChild(0).gameObject;
        currentBubbleText = currentBubbleCanvas.transform.GetChild(1).gameObject;
        int index = Random.Range(0, texts.Length);
        currentBubbleText.GetComponent<UnityEngine.UI.Text>().text = texts[index];
        currentBubble.tag = "Anxiety";
    }
    void makeAnswer()
    {
        timer = timerTotal;
        currentBubble = Instantiate(bubble, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, -0.5f, 10.0f)), Quaternion.identity); //Spawning using screen space so they always spawn below the screen and rise up
        currentBubbleCanvas = currentBubble.transform.GetChild(0).gameObject;
        currentBubbleText = currentBubbleCanvas.transform.GetChild(1).gameObject;

        currentBubbleText.GetComponent<UnityEngine.UI.Text>().text = interviewer.GetComponent<InterviewerScript>().answers[interviewer.GetComponent<InterviewerScript>().counter - 1];
        currentBubble.tag = "Answer";
    }
    void makeBadAnswer()
    {
        timer = timerTotal;
        currentBubble = Instantiate(bubble, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, -0.5f, 10.0f)), Quaternion.identity); //Spawning using screen space so they always spawn below the screen and rise up
        currentBubbleCanvas = currentBubble.transform.GetChild(0).gameObject;
        currentBubbleText = currentBubbleCanvas.transform.GetChild(1).gameObject;
        int index = Random.Range(0, interviewer.GetComponent<InterviewerScript>().falseAnswers.Length);
        currentBubbleText.GetComponent<UnityEngine.UI.Text>().text = interviewer.GetComponent<InterviewerScript>().falseAnswers[index];
        currentBubble.tag = "WrongAnswer";
    }
}
