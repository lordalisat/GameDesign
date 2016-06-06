using UnityEngine;
using System.Collections;

public class KillCollision : MonoBehaviour
{
	private GameObject player;
	private GameObject hunter;
	private bool isInside = false;

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
			isInside = true;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
			isInside = false;
	}

	public bool CanKill()
	{
		return isInside && !hunter.GetComponent<EnemyPath>().killed;
	}

	public GameObject GetTarget()
	{
		return hunter;
	}
}
