using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FPSHandAnimations : MonoBehaviour {

	FirstPersonController fpc;
	private Animator animator;
	public CharacterController controller;


	// Use this for initialization
	void Start () {
	fpc = GameObject.FindObjectOfType<FirstPersonController>();
	animator = GetComponent<Animator>();



	}

	void Run ()
	{
		if (controller.velocity.x != 0) {
			animator.SetBool("isMoving", true);
		}else {
			animator.SetBool("isMoving", false);
		}
	}

	void Jump ()
	{
		if (fpc.m_Jumping) {
			animator.SetBool ("isJumping", true);
		}
		else {
			animator.SetBool ("isJumping", false);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Run();
		Jump ();
	}
}
