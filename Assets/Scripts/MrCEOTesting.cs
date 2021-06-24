using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCEOTesting : MonoBehaviour
{
    private GameObject Arm1;
    private GameObject Arm2;
    private GameObject Face1;
    private GameObject Face2;
    private GameObject Face3;
    private GameObject Face4;


    // Start is called before the first frame update
    void Start()
    {
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
        if(Input.GetKeyDown("1"))
        {
            Arm1.GetComponent<SpriteRenderer>().enabled = false;
            Arm2.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetKeyDown("2"))
        {
            Arm1.GetComponent<SpriteRenderer>().enabled = true;
            Arm2.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Input.GetKeyDown("3"))
        {
            Face1.GetComponent<SpriteRenderer>().enabled = true;
            Face2.GetComponent<SpriteRenderer>().enabled = false;
            Face3.GetComponent<SpriteRenderer>().enabled = false;
            Face4.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Input.GetKeyDown("4"))
        {
            Face1.GetComponent<SpriteRenderer>().enabled = false;
            Face2.GetComponent<SpriteRenderer>().enabled = true;
            Face3.GetComponent<SpriteRenderer>().enabled = false;
            Face4.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Input.GetKeyDown("5"))
        {
            Face1.GetComponent<SpriteRenderer>().enabled = false;
            Face2.GetComponent<SpriteRenderer>().enabled = false;
            Face3.GetComponent<SpriteRenderer>().enabled = true;
            Face4.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (Input.GetKeyDown("6"))
        {
            Face1.GetComponent<SpriteRenderer>().enabled = false;
            Face2.GetComponent<SpriteRenderer>().enabled = false;
            Face3.GetComponent<SpriteRenderer>().enabled = false;
            Face4.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
