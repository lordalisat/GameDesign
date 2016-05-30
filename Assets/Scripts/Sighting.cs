using UnityEngine;
using System.Collections;

public class Sighting : MonoBehaviour
{

	AudioSource audio;
	public AudioClip Nope;
	public AudioClip Violin;

	// Use this for initialization
	void Start ()
	{
		audio = GetComponent<AudioSource> ();
	}

	public void playerSighted ()
	{
		audio.Stop ();
		audio.clip = Nope;
		audio.PlayOneShot (Nope, 0.5f);
		Time.timeScale = 0;
		StartCoroutine (Wait (audio.clip.length));
	}

	IEnumerator Wait (float f)
	{
		yield return new WaitForSeconds (f);
		audio.clip = Violin;
		audio.PlayOneShot (Violin, 1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
			
	}
}
