using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    public Text pointScoreCounter;

    public int lives = 3;


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
        pointScoreCounter.text = "Lives: " + lives;
    }
}
