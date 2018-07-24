using UnityEngine;
using System.Collections;

public class modelController : MonoBehaviour 
{
	public float wspeed = 2;
	public float rspeed = 6;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;

	Animator animator;

	void Start()
	{

		animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;

		if(inputDir != Vector2.zero)
		{
			float targetRot = Mathf.Atan2(inputDir.x,inputDir.y) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRot, ref turnSmoothVelocity, turnSmoothTime);
		}
		
		bool running = Input.GetKey(KeyCode.LeftShift);
		float targetspeed = ((running) ? rspeed : wspeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetspeed, ref speedSmoothVelocity, speedSmoothTime);
		
		transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
		
		float animationspeed = ((running) ? 1 : .5f) * inputDir.magnitude;
		animator.SetFloat("speedparam", animationspeed, speedSmoothTime, Time.deltaTime);
	}
}