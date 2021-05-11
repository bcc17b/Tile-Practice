using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyController : MonoBehaviour
{
	[SerializeField] private float jumpForce = 400f;
	[Range(0,1)] [SerializeField] private float blockSpeed = .36f;
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool airControl = false;
	[SerializeField] private LayerMask whatIsGround;
	[SerializeField] private Transform groundCheck;

	const float groundedRadius = .2f;
	private bool isGrounded;
	private Rigidbody2D rig;
	private bool faceRight = true;
	private Vector3 velocity = Vector3.zero;

	public UnityEvent onLanding;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> {}

	public BoolEvent onBlock;
	private bool wasBlocking = false;

	private void Awake(){
		rig = GetComponent<Rigidbody2D>();

		if(onLanding == null){
			onLanding = new UnityEvent();
		}

		if(onBlock == null){
			onBlock = new BoolEvent();
		}
	}

	private void FixedUpdate(){
		bool wasGrounded = isGrounded;
		isGrounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
		for( int i = 0; i < colliders.Length; i++){
			if (colliders[i].gameObject != gameObject){
				isGrounded = true;
				if(!wasGrounded){
					onLanding.Invoke();
				}
			}
		}
	}

    public void Move(float speed, bool jump, bool block){

		if (isGrounded || airControl)
		{

			Vector3 targetVelocity = new Vector2(speed * 10f, rig.velocity.y);


			rig.velocity = Vector3.SmoothDamp(rig.velocity, targetVelocity, ref velocity, movementSmoothing);

			if (speed > 0 && !faceRight)
			{
				Flip();
			}
			else if (speed < 0 && faceRight)
			{
				Flip();
			}
		}
		// If the player should jump...
		if (isGrounded && jump)
		{
			// Add a vertical force to the player.
			isGrounded = false;
			rig.AddForce(new Vector2(0f, jumpForce));
		}
    }

    private void Flip(){
    	faceRight = !faceRight;

    	Vector3 theScale = transform.localScale;
    	theScale.x *= -1;
    	transform.localScale = theScale;
    }
}
