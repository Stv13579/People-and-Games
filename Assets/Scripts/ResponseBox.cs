using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseBox : MonoBehaviour
{
    public GameObject interviewer;
    public GameObject txtManage;
    public AudioClip badNoise;
    public AudioClip goodNoise;


    void Start()
    {
        interviewer = GameObject.Find("MrCeo");
        txtManage = GameObject.Find("Text Manager");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //If the colliding object is an anxiety thought and is currently being held

        if ((other.gameObject.tag == "Anxiety" || other.gameObject.tag == "WrongAnswer") && other.gameObject.GetComponent<DragAndDrop>()._mouseState && other.gameObject.GetComponent<DragAndDrop>().target == other.gameObject)
        {
            

            other.gameObject.GetComponent<DragAndDrop>()._mouseState = false;
            interviewer.GetComponent<InterviewerScript>().score -= 1;
           
            //Wrong answer = more anxiety
            txtManage.GetComponent<TextManager>().score += 1;

            AudioSource.PlayClipAtPoint(badNoise, this.transform.position);

            

            Destroy(other.gameObject);          
        }

        //If the colliding dragged object is a correct answer


        if (other.gameObject.tag == "Answer" && other.gameObject.GetComponent<DragAndDrop>()._mouseState && other.gameObject.GetComponent<DragAndDrop>().target == other.gameObject)
        {
            other.gameObject.GetComponent<DragAndDrop>()._mouseState = false;
            interviewer.GetComponent<InterviewerScript>().score += 1;

            AudioSource.PlayClipAtPoint(goodNoise, this.transform.position);

            Destroy(other.gameObject);

            Destroy(this.gameObject);
        }
    }


}
