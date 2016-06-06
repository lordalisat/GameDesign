using UnityEngine;
using System.Collections;

public class EnemyPath : MonoBehaviour
{
	public GameObject waypointSet;
	public float minDist = 1;
	public float speed = 1;
	public float rSpeed = 2;
	public bool killed = false;

	private GameObject player;
	private Transform[] waypoints;

	private int num = 0;
	private bool rand = false;
	private bool go = true;

	// Use this for initialization
	void Start()
	{
		// Get the player
		player = GameObject.FindGameObjectWithTag("Player");

		// Get the amount of children on the set
		waypoints = new Transform[waypointSet.transform.childCount];

		// Add the waypoints to the array
		for (int i = 0; i < waypoints.Length; i++)
			waypoints [i] = waypointSet.transform.GetChild (i).transform;
	}

	// Update is called once per frame
	void Update()
	{
		// Don't update if we're dead, yeah...
		if (killed)
			return;

		// Get the distance to the current waypoint
		float dist = Vector3.Distance(gameObject.transform.position, waypoints[num].position);

		// Check if we can go
		if (go) {
			if (dist > minDist) {
				Move();
			} else {
				if (!rand) {
					if (num + 1 == waypoints.Length) {
						num = 0;
					} else {
						num++;
					}
				} else {
					RandomWayPoint();
				}
			}
		} else {
			WalkToPlayer();
		}
	}

	public void Move()
	{
		Quaternion direction = Quaternion.LookRotation(waypoints[num].position - gameObject.transform.position);
		gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, direction, rSpeed * Time.deltaTime);

		if (Vector3.Angle(waypoints[num].position - gameObject.transform.position, gameObject.transform.forward) < 40) {
			gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
		} else if (Vector3.Angle(waypoints[num].position - gameObject.transform.position, gameObject.transform.forward) < 130) {
			gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
			gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, direction, rSpeed * Time.deltaTime * 15);
		} else {
			gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, direction, rSpeed * Time.deltaTime);
		}
	}

	void WalkToPlayer()
	{
		Quaternion direction = Quaternion.LookRotation(player.transform.position - gameObject.transform.position);
		gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, direction, rSpeed * Time.deltaTime * 5);

		float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
		if (dist > 2 && gameObject.transform.rotation == direction) {
			gameObject.transform.position += gameObject.transform.forward * speed * 2 * Time.deltaTime;
		} else if (dist <= 2 && gameObject.transform.rotation == direction) {
			Time.timeScale = 0;
		}
	}

	void RandomWayPoint()
	{
		num = Random.Range(0, waypoints.Length);
		Vector3 direction = waypoints[num].position - gameObject.transform.position;
		RaycastHit hit;

		if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit)) {
			// ... and if the raycast hits the player...
			if (!(hit.collider.gameObject == waypoints[num].gameObject)) {
				RandomWayPoint();
			}
		}
	}

	public void SetSeen()
	{
		go = false;
	}

	public void SetKilled()
	{
		killed = true;

		GetComponent<Animation> ().enabled = false;
		GetComponent<RagdollHelper> ().Kill ();

		// Leave the lantern behind
		transform.Find ("hips/spine/chest/R_shoulder/R_arm/R_elbow/R_wrist/R_middle1/lantern").transform.parent = null;
	}
}
