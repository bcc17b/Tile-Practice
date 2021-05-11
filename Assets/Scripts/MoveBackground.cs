using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
	[SerializeField] private Transform backGround;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= backGround.position.x + 16.21883f){
        	backGround.position = new Vector2(transform.position.x + 16.21883f, backGround.position.y);
        }
        else if (transform.position.x <= backGround.position.x - 16.21883f){
        	backGround.position = new Vector2(transform.position.x - 16.21883f, backGround.position.y);
        }

        if (transform.position.y >= backGround.position.y + 8.535991f){
        	backGround.position = new Vector2(backGround.position.x, transform.position.y + 8.535991f);

        }
        else if (transform.position.y >= backGround.position.y - 8.535991f){
        	backGround.position = new Vector2(backGround.position.x, transform.position.y - 8.535991f);
        }
    }
}
