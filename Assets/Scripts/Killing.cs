using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.Characters.ThirdPerson;

public class Killing : MonoBehaviour
{
	public KillCollision enemyCollider;
	public Animation anim;
	public Animator baseAnim;
	public AudioClip killSound;

	private float animEnd = 0f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		// Only check when we're not in animation
		if (Time.time > animEnd) {
			// This indicates we're running our own animation and that it's done
			if (!baseAnim.enabled) {
				GetComponent<ThirdPersonUserControl> ().SetMoving (true);
				baseAnim.enabled = true;

				// Only kill the enemy when we're STILL behind him
				if (enemyCollider.CanKill ()) {
					enemyCollider.GetTarget ().GetComponent<EnemyPath> ().SetKilled ();

					AudioSource src = GetComponent<AudioSource> ();
					src.Stop ();
					src.clip = killSound;
					src.PlayOneShot (src.clip, 0.5f);
				}

				// Check if we're behind the enemy and pressing space
			} else if (Input.GetKeyDown (KeyCode.Space) && enemyCollider.CanKill ()) {
				GetComponent<ThirdPersonUserControl> ().SetMoving (false);
				baseAnim.enabled = false;

				anim = GetComponentInChildren<Animation> ();
				anim.Play (anim.clip.name);

				animEnd = Time.time + anim.clip.length;
			}
		} else if (!baseAnim.enabled) {
			Transform enemy = enemyCollider.GetTarget ().transform;
			transform.position = enemy.position + enemy.forward * -0.6f;
			transform.rotation = enemy.rotation;
		}
	}
}
