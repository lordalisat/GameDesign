using UnityEngine;
using System.Collections;
using System;

public class Killing : MonoBehaviour
{
	public KillCollision enemyCollider;
	public Animation anim;
	public Animator baseAnim;
	public AudioClip killSound;
	public AudioClip dropSound;

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
				baseAnim.enabled = true;

				// Only kill the enemy when we're STILL behind him
				if (enemyCollider.CanKill()) {
					//Destroy(enemyCollider.GetTarget());
					//enemyCollider.GetTarget().transform.Rotate(new Vector3(-90, 0, 0));
					//enemyCollider.GetTarget().GetComponent<RagdollHelper>().ragdolled = true;

					enemyCollider.GetTarget ().GetComponent<EnemyPath> ().SetKilled ();

					var children = GetComponents<AudioSource> ();
					for (int i = 0; i < children.Length; i++) {
						AudioSource src = children [i];
						src.Stop ();
						src.clip = i == 0 ? killSound : dropSound;
						src.PlayOneShot(src.clip, 0.5f);
					}

					// To-Do: Actually get all components, and see which one is playing
					// And do something else with the thud
				}

			// Check if we're behind the enemy and pressing space
			} else if (Input.GetKeyDown(KeyCode.Space) && enemyCollider.CanKill()) {
				baseAnim.enabled = false;

				anim = GetComponentInChildren<Animation>();
				anim.Play(anim.clip.name);

				animEnd = Time.time + anim.clip.length;
			}
		}
	}
}
