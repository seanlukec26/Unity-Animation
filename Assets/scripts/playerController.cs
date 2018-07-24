using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour 
{
	
	public Animator anim;

	public bool isIdle = true;
	public bool isWalking = false;
	public bool isRunning = false;
	public bool isCrouching = false;
	public bool isJumping = false;
	public bool isLeft = false;
	public bool isRight = false;
	public float turnValue = 0.0f;
	public float speedValue = 0.0f;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		turnValue = 2.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		anim.SetBool("walking",Input.GetKey (KeyCode.W));
		isWalking = Input.GetKey (KeyCode.W);
		
		anim.SetBool("running",Input.GetKey (KeyCode.LeftShift));
		isRunning = Input.GetKey (KeyCode.LeftShift);
		
		anim.SetBool("crouching",Input.GetKey (KeyCode.LeftControl));
		isCrouching = Input.GetKey (KeyCode.LeftControl);
		
		anim.SetBool("jumping",Input.GetKey (KeyCode.Space));
		isJumping = Input.GetKey (KeyCode.Space);
		
		isLeft = Input.GetKey (KeyCode.A);
		isRight = Input.GetKey (KeyCode.D);
		
		if (isLeft) 
		{
			anim.SetFloat("turnValue",0.0f);
		}
		
		else if (isRight) 
		{
			anim.SetFloat("turnValue",5.0f);
		}
		
		else if(!isLeft && !isRight)
		{
			anim.SetFloat("turnValue",2.5f);
		}
		
		if (!Input.GetKeyDown(KeyCode.W))
		{
			isRunning = false;
		}
		
		//crouch walk
		if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey (KeyCode.W))
		{
			isWalking = true;
		}
		//Walk Backwards
		if (Input.GetKey (KeyCode.S))
		{
			transform.forward = new Vector3(0f, 0f, -1f);
		}
	}
	
	
}