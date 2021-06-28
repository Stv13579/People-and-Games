using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxTrack : MonoBehaviour
{
    public float anx = 0;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        this.hideFlags = HideFlags.None;
    }

    private void OnLevelWasLoaded(int level)
    {
        
        
        if (level > 3)
        {
            GameObject.Find("GameManager").GetComponent<EndManager>().score = anx / 3;
            Destroy(this.gameObject);
        }
        else
        {
            GameObject.Find("Text Manager").GetComponent<TextManager>().score = anx / 3;
        }
    }
}
