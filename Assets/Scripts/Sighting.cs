using UnityEngine;
using System.Collections;

public class Sighting : MonoBehaviour
{
	private AudioSource player;
	public AudioClip Nope;
	public AudioClip Violin;

	// Use this for initialization
	void Start()
	{
		player = GetComponent<AudioSource>();
	}

	public void playerSighted()
	{
		player.Stop();
		player.clip = Nope;
		player.PlayOneShot(Nope, 0.5f);
		Time.timeScale = 0;
		StartCoroutine(Wait(player.clip.length));
	}

	IEnumerator Wait(float f)
	{
		yield return new WaitForSeconds(f);
		player.clip = Violin;
		player.PlayOneShot(Violin, 1f);
	}
	
	// Update is called once per frame
	void Update()
	{
			
	}
}
