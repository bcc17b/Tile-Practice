using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMovement : MonoBehaviour
{
	public MyController controller;
	public Animator animator;

	public float moveSpeed = 40f;

	//public Layermask enemies;

	float horizontalMove = 0f;
	bool jump = false;
	bool block = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButton("Jump")){
        	jump = true;
        	animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Block")){
        	block = true;
        	animator.SetBool("Block", true);
        }
    }

    public void OnLanding (){
    	animator.SetBool("isJumping", false);
    }

    public void	OnAttackFinish(){
    	animator.SetBool("Attack", false);
    }

    public void	OnBlockFinish(bool isBlocking){
    	animator.SetBool("Block", isBlocking);
    }

    void FixedUpdate(){
    	controller.Move(horizontalMove * Time.fixedDeltaTime, jump, block);
    	jump = false;
    }
}
