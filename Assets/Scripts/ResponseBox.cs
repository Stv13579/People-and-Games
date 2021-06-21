using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseBox : MonoBehaviour
{
    public GameObject interviewer;
    // Start is called before the first frame update
    void Start()
    {
        interviewer = GameObject.Find("MrCeo");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //If the colliding object is an anxiety thought and is currently being held

        if ((other.gameObject.tag == "Anxiety" || other.gameObject.tag == "WrongAnswer") && other.gameObject.GetComponent<DragAndDrop>()._mouseState && other.gameObject.GetComponent<DragAndDrop>().target == other.gameObject)
        {
            other.gameObject.GetComponent<DragAndDrop>()._mouseState = false;
            interviewer.GetComponent<InterviewerScript>().score -= 1;

            //Shouldn't destroy since the question is unanswered?
            //Destroy(this.gameObject);

            Destroy(other.gameObject);

        }
    }


}
