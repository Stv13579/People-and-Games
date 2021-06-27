using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxTrack : MonoBehaviour
{
    public float anx = 0;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded(int level)
    {
        GameObject.Find("Text Manager").GetComponent<TextManager>().score = anx / 3;
        if (level > 3)
        {
            Destroy(this.gameObject);
        }
    }
}
