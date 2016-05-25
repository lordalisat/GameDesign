using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
	public float fieldOfViewAngle = 80f;           // Number of degrees, centred on forward, for the enemy see.
	public bool playerSighted;                      // Whether or not the player is currently sighted.
	public Sighting sighting;

	private SphereCollider col;                     // Reference to the sphere collider trigger component.
	private GameObject player;                      // Reference to the player.
	private bool caught = false;

	void Awake ()
	{
		// Setting up the references.
		col = GetComponent<SphereCollider>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if (other.gameObject == player) {

			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle (direction, transform.forward);

			// If the angle between forward and where the player is, is less than half the angle of view...
			if (angle < fieldOfViewAngle * 0.5f) {
				RaycastHit hit;

				// ... and if a raycast towards the player hits something...
				if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit, col.radius)) {
					// ... and if the raycast hits the player...
					if (hit.collider.gameObject == player) {
						if (!caught) {
							caught = true;
							// ... the player is in sight.
							sighting.playerSighted ();
						}
					}
				}
			}
		}
	}
}