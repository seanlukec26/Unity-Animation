using UnityEngine;
using System.Collections;

public class NPCchase : MonoBehaviour {
	
	public Transform player;
	public Transform head;
	Animator anim;
	
	//bool pursuing = false;
	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.2f;
	public float speed = 1.5f;
	float accuracyWP = 5.0f;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = player.position - this.transform.position;
		direction.y = 0;
		
		float angle = Vector3.Angle(direction,head.up);
		if(state == "patrol" && waypoints.Length > 0)
		{
			anim.SetBool("isIdle",false);
			anim.SetBool("Walking",true);
			if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position)<accuracyWP)
			{
				currentWP = Random.Range(0,waypoints.Length);
				/*currentWP++;
				if(currentWP >= waypoints.Length)
				{
					currentWP = 0;
				}*/
			}
			
			direction = waypoints[currentWP].transform.position - transform.position;
			this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
			this.transform.Translate(0,0, Time.deltaTime * speed);
		}
		if(Vector3.Distance(player.position, this.transform.position)<15 && (angle<30 || state == "pursuing"))
		{
			state = "pursuing";
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
			
			//anim.SetBool("isIdle",false);
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,Time.deltaTime * speed);
				anim.SetBool("Walking",true);
				anim.SetBool("Attacking",false);
			}
			else
			{
				anim.SetBool("Attacking",true);
				anim.SetBool("Walking",false);
			}
		}
		else
		{
			//anim.SetBool("isIdle", true);
			anim.SetBool("Walking", true);
			anim.SetBool("Attacking", false);
			state = "patrol";
		}
	}
}
