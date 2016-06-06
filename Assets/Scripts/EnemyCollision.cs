using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour
{
	public Sighting sighting;
	private GameObject player;
	private BoxCollider box;
	private Transform dragTransform;
	private bool dragging = false;

	void Awake()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag("Player");
		dragTransform = player.transform;
		box = GetComponent<BoxCollider> ();
	}

	void Update()
	{
		if (dragging) {
			if (Input.GetMouseButton (0)) {
				transform.parent.position = TranslateDeg(dragTransform);
			} else {
				// Save a variable
				dragging = false;

				// Make the object static again
				GetComponentInParent<RagdollHelper> ().Kill (true);
			}
		} else {
			if (GetComponentInParent<EnemyPath> ().killed) {
				Transform body = transform.parent.Find ("hips").transform;
				box.center = body.localPosition;

				Vector3 diff = player.transform.position - body.position;
				if (Input.GetMouseButtonDown (0) && diff.magnitude < 2f) {
					// Set variable
					dragging = true;

					// Enable ragdoll physics
					GetComponentInParent<RagdollHelper> ().Kill ();
				}
			}
		}
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			if (!GetComponentInParent<EnemyPath> ().killed) {
				sighting.playerSighted ();
				GetComponentInParent<EnemyPath> ().SetSeen ();
			}
		}
	}

	private Vector3 TranslateDeg(Transform t)
	{
		return dragTransform.position;
	}
}
