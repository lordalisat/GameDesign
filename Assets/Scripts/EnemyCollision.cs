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
		dragTransform = player.transform.Find ("DragPos");
		box = GetComponent<BoxCollider> ();
	}

	void Update()
	{
		if (dragging) {
			if (Input.GetMouseButton (0)) {
				transform.parent.position = dragTransform.position;
			} else {
				dragging = false;
			}
		} else {
			if (GetComponentInParent<EnemyPath> ().killed) {
				Transform body = transform.parent.Find ("hips").transform;
				box.center = body.localPosition;

				Vector3 diff = player.transform.position - body.position;
				if (Input.GetMouseButtonDown (0) && diff.magnitude < 2f) {
					dragging = true;
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
}
