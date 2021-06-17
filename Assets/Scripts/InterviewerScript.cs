using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewerScript : MonoBehaviour
{
    public GameObject ResponseBox;
    private GameObject question;
    private GameObject questionCanvas;
    private GameObject questionText;
    public string[] questions;
    private int counter = 0;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate question box, add question to box. Same mechanism as thought bubbles
        question = Instantiate(ResponseBox, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10.0f)), Quaternion.identity); //Spawning using screen space
        questionCanvas = question.transform.GetChild(0).gameObject;
        questionText = questionCanvas.transform.GetChild(0).gameObject;
        questionText.GetComponent<UnityEngine.UI.Text>().text = questions[counter];
        counter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (question == null)
        {
            //New question box if old on is answered
            question = Instantiate(ResponseBox, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10.0f)), Quaternion.identity); //Spawning using screen space so they always spawn below the screen and rise up
            questionCanvas = question.transform.GetChild(0).gameObject;
            questionText = questionCanvas.transform.GetChild(0).gameObject;
            questionText.GetComponent<UnityEngine.UI.Text>().text = questions[counter];
            counter += 1;
        }
    }
}
