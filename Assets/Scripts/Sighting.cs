using UnityEngine;
using System.Collections;

public class Sighting : MonoBehaviour
{

	public AudioClip Nope;
	public AudioClip Violin;

	private GameObject player;
	private AudioSource audioPlayer;

	private bool caught = false;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		audioPlayer = GetComponent<AudioSource>();
	}

	public void playerSighted()
	{
		if (!caught) {
			caught = true;
			audioPlayer.Stop();
			audioPlayer.clip = Nope;
			audioPlayer.PlayOneShot(Nope, 0.5f);
			player.SendMessage("SetMoving", false);
			StartCoroutine(Wait(audioPlayer.clip.length));
		}
	}

	IEnumerator Wait(float f)
	{
		yield return new WaitForSeconds(f);
		audioPlayer.clip = Violin;
		audioPlayer.PlayOneShot(Violin, 1f);
	}
	
	// Update is called once per frame
	void Update()
	{
			
	}
}
