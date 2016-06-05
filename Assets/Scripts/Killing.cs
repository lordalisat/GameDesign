using UnityEngine;
using System.Collections;
using System;

public class Killing : MonoBehaviour
{
	public KillCollision enemyCollider;
	public Animation anim;
	public Animator baseAnim;

	private DateTime animEnd = DateTime.Now;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// Only check when we're not in animation
		if (DateTime.Now > animEnd) {
			// This indicates we're running our own animation and that it's done
			if (!baseAnim.enabled) {
				baseAnim.enabled = true;

				// Only kill the enemy when we're STILL behind him
				if (enemyCollider.CanKill()) {
					//Destroy(enemyCollider.GetTarget());
					enemyCollider.GetTarget().transform.Rotate(new Vector3(-90, 0, 0));
				}

			// Check if we're behind the enemy and pressing space
			} else if (Input.GetKeyDown(KeyCode.Space) && enemyCollider.CanKill()) {
				baseAnim.enabled = false;

				anim = GetComponentInChildren<Animation>();
				anim.Play(anim.clip.name);

				animEnd = DateTime.Now.AddSeconds(anim.clip.length);
			}
		}
	}
}
