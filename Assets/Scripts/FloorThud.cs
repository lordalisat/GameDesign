using UnityEngine;
using System.Collections;

public class FloorThud : MonoBehaviour {

	public AudioClip thudSound;
	private AudioSource audioPlayer;

	// Use this for initialization
	void Start () {
		audioPlayer = GetComponent<AudioSource> ();
	}
	
	void OnCollisionEnter(Collision collision)
	{
		//Increase score if this ragdoll part collides with something else
		//than another ragdoll part with sufficient velocity. 
		//If the colliding object is another ragdoll part, it will have the same root, hence the inequality check.
		if (transform.root != collision.transform.root)
		{
			audioPlayer.Stop ();
			audioPlayer.clip = thudSound;
			audioPlayer.Play ();
		}
	}
}
