using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleMove : MonoBehaviour
{
    private float vSpeed;
    private float hSpeed;
    public int moveMode;
    Vector3 leftPos;
    Vector3 rightPos;
    Vector3 bottomPos;

    Renderer rendererMesh;

    public Sprite[] bubbles;
    private float spriteSwitchTime;

    public TextManager textmanager;
    // Start is called before the first frame update
    void Start()
    {
        textmanager = FindObjectOfType<TextManager>();
        //Randomise vertical and horizontal speeds, and movement mode
        vSpeed = Random.Range(0.05f, 0.15f);
        hSpeed = Random.Range(-0.15f, 0.3f);
        moveMode = Random.Range(1, 5);
        rendererMesh = GetComponent<MeshRenderer>();
        this.GetComponent<Rigidbody>().WakeUp();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spriteSwitchTime -= Time.deltaTime;
        if (spriteSwitchTime <= 0)
        {
            this.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = bubbles[Random.Range(0, bubbles.Length)];
            spriteSwitchTime = 0.1f;
        }
       


        //Random movement options
        switch (moveMode)
        {
            case 1:
                this.transform.position = new Vector3(this.transform.position.x + (hSpeed * Mathf.Cos(Time.time)), this.transform.position.y + vSpeed, this.transform.position.z);
                break;
            case 2:
                this.transform.position = new Vector3(this.transform.position.x + (hSpeed * Mathf.Sin(Time.time)), this.transform.position.y + vSpeed, this.transform.position.z);
                break;
            case 3:
                this.transform.position = new Vector3(this.transform.position.x + (-hSpeed * Mathf.Cos(Time.time)), this.transform.position.y + vSpeed, this.transform.position.z);
                break;
            case 4:
                this.transform.position = new Vector3(this.transform.position.x + (-hSpeed * Mathf.Sin(Time.time)), this.transform.position.y + vSpeed, this.transform.position.z);
                break;
            default:
                this.transform.position = new Vector3(this.transform.position.x + (hSpeed * Mathf.Cos(Time.time)), this.transform.position.y + vSpeed, this.transform.position.z);
                break;

        }
        //Calculate the bottom, left, and right edges of the bubbles in screen space
        bottomPos = Camera.main.WorldToViewportPoint(new Vector3(transform.position.x, transform.position.y - (rendererMesh.bounds.size.y / 2), transform.position.z));
        rightPos = Camera.main.WorldToViewportPoint(new Vector3(transform.position.x + (rendererMesh.bounds.size.x / 2), transform.position.y, transform.position.z));
        leftPos = Camera.main.WorldToViewportPoint(new Vector3(transform.position.x - (rendererMesh.bounds.size.x / 2), transform.position.y, transform.position.z));


        //If the bubble is off the top of the screen, destroy it and increment anxiety counter
        if (bottomPos.y > 1.0f)
        {
            textmanager.score += 1;
            Destroy(this.gameObject);
        }
        //Keeps the bubbles from going off the side of the screen
        if (rightPos.x > 1.0f)
        {
            this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, rightPos.y, rightPos.z)) - new Vector3(rendererMesh.bounds.size.x / 2, 0.0f, 0.0f);
        }
        if (leftPos.x < 0.0f)
        {
            this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, leftPos.y, leftPos.z)) + new Vector3(rendererMesh.bounds.size.x / 2, 0.0f, 0.0f);
        }

    }

}

