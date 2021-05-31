using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
    public float speed;
    public GameObject textmanager;
    // Start is called before the first frame update
    void Start()
    {
        textmanager = FindObjectOfType<TextManager>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + (0.01f * Mathf.Cos(Time.time)), this.transform.position.y + speed, this.transform.position.z);
        if (this.transform.position.y > 5)
        {
            textmanager.GetComponent<TextManager>().score += 1;
            Destroy(this.gameObject);
        }
    }
}
