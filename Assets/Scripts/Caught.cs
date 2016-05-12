using UnityEngine;
using System.Collections;

public class Caught : MonoBehaviour {
	


	void Start () {
		GameObject player = GameObject.Find ("Infiltrator");
		Transform playerTransform = player.transform;
		Vector3 position = playerTransform.position;
	
	}

	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.Find ("Infiltrator");
		Transform playerTransform = player.transform;
		Vector3 position = playerTransform.position;
		if (position.z > 5){
			AudioSource MetalGear = GetComponent<AudioSource>();
			GetComponent<AudioSource>().Play();
			AudioSource Soundtrack = GetComponent<AudioSource>();
			GetComponent<AudioSource>().Stop();
		}
	}
}