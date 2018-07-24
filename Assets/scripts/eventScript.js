#pragma strict

function playAudio (aud:AudioClip) 
{
	GetComponent.<AudioSource>().clip = aud;
	GetComponent.<AudioSource>().Play();
}

var newpar : GameObject;  
function playParticle(par:GameObject)
{
	if(par)
	{
		newpar = Instantiate(par,transform.position,transform.rotation);
		Destroy(newpar,3);
	}
	//Instantiate(par,transform.position, transform.rotation);
	//Destroy(par);
}
     
