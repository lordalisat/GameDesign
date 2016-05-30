using UnityEngine;
using System.Collections;
using System;

public class Killing : MonoBehaviour
{
	public KillCollision collider;
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
		if (!collider.CanKill())
			return;

		if (DateTime.Now > animEnd)
		{
			if (!baseAnim.enabled)
			{
				baseAnim.enabled = true;
			}
			else if (Input.GetKeyDown(KeyCode.Space))
			{
				Destroy(collider.GetTarget());
				baseAnim.enabled = false;

				anim = GetComponentInChildren<Animation>();
				anim.Play(anim.clip.name);

				animEnd = DateTime.Now.AddSeconds(anim.clip.length);
			}
		}
	}
}
