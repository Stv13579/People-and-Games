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
<<<<<<< Updated upstream
        if ((other.gameObject.tag == "Anxiety" || other.gameObject.tag == "WrongAnswer") && other.gameObject.GetComponent<DragAndDrop>()._mouseState)
=======
        if (other.gameObject.tag == "Anxiety" && other.gameObject.GetComponent<DragAndDrop>()._mouseState && other.gameObject.GetComponent<DragAndDrop>().target == other.gameObject)
>>>>>>> Stashed changes
        {
            other.gameObject.GetComponent<DragAndDrop>()._mouseState = false;
            interviewer.GetComponent<InterviewerScript>().score -= 1;
<<<<<<< Updated upstream
            //Shouldn't destroy since the question is unanswered?
            //Destroy(this.gameObject);
=======
            Destroy(other.gameObject);

            Destroy(this.gameObject);
>>>>>>> Stashed changes
        }
    }


}
