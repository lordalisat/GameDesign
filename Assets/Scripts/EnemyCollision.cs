using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	private GameObject player;                      // Reference to the player.
	public Sighting sighting;


	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.gameObject == player) {
			sighting.playerSighted ();
			gameObject.GetComponentInParent<EnemyPath> ().SetSeen ();
		}
	}
}
