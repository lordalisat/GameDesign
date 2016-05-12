using UnityEngine;
using System.Collections;

public class Sighting : MonoBehaviour {

	AudioSource audio;
	public AudioClip MetalGear;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}	

	public void playerSighted () {
		audio.Stop ();
		audio.clip = MetalGear;
		audio.PlayOneShot (MetalGear, 0.5f);
		Debug.Log ("nope");
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
