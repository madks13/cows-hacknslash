﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingDragon : MonoBehaviour {

	private NavMeshAgent navMeshAgent;
	private Animator anim_Controller;
	private bool m_Running;
	
	[SerializeField]
	private GameObject Target;
	public float Range;
	[SerializeField]
	[Range(0.0f, 5f)]
	private float animationSpeed = 2.5f;

	// Use this for initialization
	void Start () {
		anim_Controller = GetComponent<Animator>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		anim_Controller.SetBool("running", true);
	}
	
	void FixedUpdate(){

		anim_Controller.speed = animationSpeed;

		if(Vector3.Distance(Target.transform.position, transform.position) <= Range)
    	{
    		navMeshAgent.destination = Target.transform.position;
    	}

		
		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
			m_Running = false;
			anim_Controller.SetBool("running", m_Running);
			//navMeshAgent.updatePosition = false;
		} else {
			m_Running = true;
			anim_Controller.SetBool("running", m_Running);
		}
	}
}
