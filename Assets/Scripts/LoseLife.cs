using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLife : MonoBehaviour
{
    LivesCounter livesCounter;

    // Start is called before the first frame update
    void Start()
    {
        livesCounter = GameObject.Find("Canvas").GetComponent<LivesCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            livesCounter.lives -= 1;
            if (livesCounter.lives <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
