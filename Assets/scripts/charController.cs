using UnityEngine;
using System.Collections;

public class charController : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float move = Input.GetAxis("Vertical");
		anim.SetFloat("speedparam", move);
	}
}
