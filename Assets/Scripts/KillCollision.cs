using UnityEngine;
using System.Collections;

public class KillCollision : MonoBehaviour
{
	private GameObject player;
	private GameObject hunter;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		hunter = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
			player.GetComponent<Killing> ().SetCollider (hunter);
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
			player.GetComponent<Killing> ().SetCollider (null);
	}
}
