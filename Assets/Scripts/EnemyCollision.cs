using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	private BoxCollider box;                     // Reference to the sphere collider trigger component.
	private GameObject player;                      // Reference to the player.
	public Sighting sighting;


	void Awake ()
	{
		// Setting up the references.
		box = GetComponent<BoxCollider>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			sighting.playerSighted ();
		}
	}
}
