using UnityEngine;
using System.Collections;

public class NPCchase1 : MonoBehaviour {
	
	public Transform player;
	public Transform head;
	Animator anim;
	
	bool pursuing = false;
	
	
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

		if(Vector3.Distance(player.position, this.transform.position)<15 && (angle<30 || pursuing))
		{
			pursuing = true;
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.2f);
			
			anim.SetBool("isIdle",false);
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,0.05f);
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
			anim.SetBool("isIdle", true);
			anim.SetBool("Walking", true);
			anim.SetBool("Attacking", false);
			pursuing = false;
		}
	}
}
