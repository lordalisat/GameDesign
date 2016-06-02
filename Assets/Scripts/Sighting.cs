using UnityEngine;
using System.Collections;

public class Sighting : MonoBehaviour
{

	AudioSource audio;
	public AudioClip Nope;
	public AudioClip Violin;

	private GameObject player;

	private bool caught = false;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		audio = GetComponent<AudioSource>();
	}

	public void playerSighted()
	{
		if (!caught) {
			caught = true;
			audio.Stop();
			audio.clip = Nope;
			audio.PlayOneShot(Nope, 0.5f);
			player.SendMessage("SetMoving");
			StartCoroutine(Wait(audio.clip.length));
		}
	}

	IEnumerator Wait(float f)
	{
		yield return new WaitForSeconds(f);
		audio.clip = Violin;
		audio.PlayOneShot(Violin, 1f);
	}
	
	// Update is called once per frame
	void Update()
	{
			
	}
}
