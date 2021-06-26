using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject gameManage;

    float questionTime = 5;
    bool askingQuestion;

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
        question = Instantiate(ResponseBox, Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0.25f, 10.0f)), Quaternion.identity); //Spawning using screen space
        questionCanvas = question.transform.GetChild(0).gameObject;
        questionText = questionCanvas.transform.GetChild(0).gameObject;
        questionText.GetComponent<TextMeshProUGUI>().text = questions[counter];
        counter += 1;

       
        Face1 = this.transform.GetChild(1).gameObject;
        Face2 = this.transform.GetChild(2).gameObject;
        Face3 = this.transform.GetChild(3).gameObject;
        Face4 = this.transform.GetChild(4).gameObject; 
        if (hasArm)
        {
            Arm1 = this.transform.GetChild(5).gameObject;
            Arm2 = this.transform.GetChild(6).gameObject;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (question == null)
        {
            if (counter > questions.Length - 1)
            {
                gameManage.GetComponent<GameManager>().gameOver = true;
                
            }
            else
            {
                //New question box if old one is answered
                question = Instantiate(ResponseBox, Camera.main.ViewportToWorldPoint(new Vector3(0.25f, 0.25f, 10.0f)), Quaternion.identity); //Spawning using screen space so they always spawn below the screen and rise up
                questionCanvas = question.transform.GetChild(0).gameObject;
                questionText = questionCanvas.transform.GetChild(0).gameObject;
                questionText.GetComponent<TextMeshProUGUI>().text = questions[counter];
                counter += 1;
                askingQuestion = true;
            }
           
        }
        if (askingQuestion)
        {
            askQuestion();
            questionTime -= Time.deltaTime;
            if (questionTime <= 0)
            {
                questionTime = 5;
                askingQuestion = false;
            }
        }

        if (score == 0 && !askingQuestion)
        {
            neutral();
        }
        if (score > 0 && !askingQuestion)
        {
            content();
        }
        if (score < 0 && !askingQuestion)
        {
            discomfort();
        }
    }

    void askQuestion()
    {
        if (hasArm)
        {
            Arm1.GetComponent<SpriteRenderer>().enabled = false;
            Arm2.GetComponent<SpriteRenderer>().enabled = true;
        }
       

        Face1.GetComponent<SpriteRenderer>().enabled = true;
        Face2.GetComponent<SpriteRenderer>().enabled = false;
        Face3.GetComponent<SpriteRenderer>().enabled = false;
        Face4.GetComponent<SpriteRenderer>().enabled = false;
    }

    void discomfort()
    {

        if (hasArm)
        {
            Arm1.GetComponent<SpriteRenderer>().enabled = true;
            Arm2.GetComponent<SpriteRenderer>().enabled = false;
        }
        Face1.GetComponent<SpriteRenderer>().enabled = false;
        Face2.GetComponent<SpriteRenderer>().enabled = true;
        Face3.GetComponent<SpriteRenderer>().enabled = false;
        Face4.GetComponent<SpriteRenderer>().enabled = false;
    }

    void content()
    {
        if (hasArm)
        {
            Arm1.GetComponent<SpriteRenderer>().enabled = true;
            Arm2.GetComponent<SpriteRenderer>().enabled = false;
        }
        Face1.GetComponent<SpriteRenderer>().enabled = false;
        Face2.GetComponent<SpriteRenderer>().enabled = false;
        Face3.GetComponent<SpriteRenderer>().enabled = false;
        Face4.GetComponent<SpriteRenderer>().enabled = true;
    }

    void neutral()
    {
        if (hasArm)
        {
            Arm1.GetComponent<SpriteRenderer>().enabled = true;
            Arm2.GetComponent<SpriteRenderer>().enabled = false;
        }
        Face1.GetComponent<SpriteRenderer>().enabled = false;
        Face2.GetComponent<SpriteRenderer>().enabled = false;
        Face3.GetComponent<SpriteRenderer>().enabled = true;
        Face4.GetComponent<SpriteRenderer>().enabled = false;
    }
}
