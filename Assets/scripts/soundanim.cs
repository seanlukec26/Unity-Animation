using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class soundanim : MonoBehaviour 
{
    void Update() 
	{
		if (Input.GetKeyDown("w")||Input.GetKeyDown("s")||Input.GetKeyDown("a")||Input.GetKeyDown("d"))
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			audio.Play(44100);
			audio.loop = true;
		}
		else
		{
			GetComponent<AudioSource>().loop = false;
		}
    }
}
