using UnityEngine;
using System.Collections;

public class EnemyPath : MonoBehaviour {

	public GameObject[] wayPoints;
	public int num = 0;

	public float minDist = 1;
	public float speed = 1;
	public float rSpeed = 2;

	public bool rand = false;
	public bool go = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (gameObject.transform.position, wayPoints [num].transform.position);

		if (go) {
			if (dist > minDist) {
				Move ();
			} else {
				if (!rand) {
					if (num + 1 == wayPoints.Length) {
						num = 0;
					} else {
						num++;
					}
				} else {
					RandomWayPoint ();
				}
			}
		}
	}

	public void Move(){
		Quaternion direction = Quaternion.LookRotation (wayPoints [num].transform.position - gameObject.transform.position);
		gameObject.transform.rotation = Quaternion.RotateTowards (gameObject.transform.rotation, direction, Time.deltaTime + rSpeed);
		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
	}

	void RandomWayPoint(){
		num = Random.Range (0, wayPoints.Length);
		Vector3 direction = wayPoints [num].transform.position - gameObject.transform.position;
		RaycastHit hit;
		if (Physics.Raycast (transform.position + transform.up, direction.normalized, out hit)) {
			// ... and if the raycast hits the player...
			if (!(hit.collider.gameObject == wayPoints[num])) {
				RandomWayPoint ();
			}
		}
	}
}
