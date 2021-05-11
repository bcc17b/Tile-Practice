using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    public Text pointScoreCounter;

    public int score = 0;


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Canvas");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        pointScoreCounter.text = "Score: " + score;
    }
}
