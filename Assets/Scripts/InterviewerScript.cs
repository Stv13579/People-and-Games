using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewerScript : MonoBehaviour
{
    public GameObject ResponseBox;
    [HideInInspector] public GameObject question;
    private GameObject questionCanvas;
    private GameObject questionText;
    public string[] questions;
    //Should correspond to the question (i.e answers[0] fits with questions[0])
    public string[] answers;
    public string[] falseAnswers;
    [HideInInspector] public int counter = 0;
    public int score = 0;

    public bool hasArm;
    //Variables to control the interviewer's expressions
    private GameObject Arm1;
    private GameObject Arm2;
    private GameObject Face1;
    private GameObject Face2;
    private GameObject Face3;
    private GameObject Face4;


    void Start()
    {
        //Instantiate question box, add question to box. Same mechanism as thought bubbles
        question = Instantiate(ResponseBox, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10.0f)), Quaternion.identity); //Spawning using screen space
        questionCanvas = question.transform.GetChild(0).gameObject;
        questionText = questionCanvas.transform.GetChild(0).gameObject;
        questionText.GetComponent<UnityEngine.UI.Text>().text = questions[counter];
        counter += 1;

        Arm1 = this.transform.GetChild(1).gameObject;
        Arm2 = this.transform.GetChild(2).gameObject;
        Face1 = this.transform.GetChild(3).gameObject;
        Face2 = this.transform.GetChild(4).gameObject;
        Face3 = this.transform.GetChild(5).gameObject;
        Face4 = this.transform.GetChild(6).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (question == null)
        {
            //New question box if old one is answered
            question = Instantiate(ResponseBox, Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10.0f)), Quaternion.identity); //Spawning using screen space so they always spawn below the screen and rise up
            questionCanvas = question.transform.GetChild(0).gameObject;
            questionText = questionCanvas.transform.GetChild(0).gameObject;
            questionText.GetComponent<UnityEngine.UI.Text>().text = questions[counter];
            counter += 1;
        }
    }

    void askQuestion()
    {

    }

    void discomfort()
    {

    }

    void content()
    {

    }

    void neutral()
    {

    }
}
