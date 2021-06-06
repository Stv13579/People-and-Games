using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour
{
    private float vSpeed;
    private float hSpeed;
    public int moveMode;
    Vector3 leftPos;
    Vector3 rightPos;
    Vector3 bottomPos;

    Renderer rendererMesh;


    public TextManager textmanager;
    // Start is called before the first frame update
    void Start()
    {
        textmanager = FindObjectOfType<TextManager>();
        vSpeed = Random.Range(0.05f, 0.15f);
        hSpeed = Random.Range(-0.15f, 0.3f);
        moveMode = Random.Range(1, 5);
        rendererMesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        bottomPos = Camera.main.WorldToViewportPoint(new Vector3(transform.position.x, transform.position.y - (rendererMesh.bounds.size.y / 2), transform.position.z));
        rightPos = Camera.main.WorldToViewportPoint(new Vector3(transform.position.x + (rendererMesh.bounds.size.x / 2), transform.position.y, transform.position.z));
        leftPos = Camera.main.WorldToViewportPoint(new Vector3(transform.position.x - (rendererMesh.bounds.size.x / 2), transform.position.y, transform.position.z));


        //leftPos = Camera.main.WorldToViewportPoint(transform.position);

        if (bottomPos.y > 1.0f)
        {
            textmanager.score += 1;
            Destroy(this.gameObject);
        }
        if (rightPos.x > 1.0f)
        {
            this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, rightPos.y, rightPos.z)) - new Vector3(rendererMesh.bounds.size.x / 2, 0.0f, 0.0f);
            //this.transform.position = new Vector3(5.65f, this.transform.position.y, this.transform.position.z);
        }
        if (leftPos.x < 0.0f)
        {
            this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, leftPos.y, leftPos.z)) + new Vector3(rendererMesh.bounds.size.x / 2, 0.0f, 0.0f);
        }

    }
}
