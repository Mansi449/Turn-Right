﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualCar : MonoBehaviour {

	private int carState;
	public float increaseRate;
	private Vector3 ycarRotation;
	public float decreaseRate;
	public int mass;
	public int drag;
	public GameObject player;

	[SerializeField]
	private float freeVelocity;

	private enum State{
		STRAIGHT, TURN, FREE
	};

	State current;

	// Use this for initialization
	void Start () {
		current = State.STRAIGHT;
		ycarRotation = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		switch (current){
		
			case State.STRAIGHT:
			Debug.Log("in straight");
				if(ycarRotation.y>0){
					ycarRotation.y = ycarRotation.y - decreaseRate*Time.deltaTime;
				}
				if(Input.GetMouseButtonDown(0)){
					current = State.TURN;
				}
				transform.localRotation = Quaternion.Euler(ycarRotation);
				if(transform.position.x < -100){
					current = State.FREE;
					transform.gameObject.AddComponent<Rigidbody>();
					Rigidbody rb = GetComponent<Rigidbody>();
				//transform.Translate(Vector3.forward*freeVelocity*Time.deltaTime);
				rb.velocity = transform.forward * freeVelocity;
				rb.mass = mass;
				rb.drag = drag;
				}
				break;

			case State.TURN:
			Debug.Log("in turn");
			
				if(Input.GetMouseButton(0)){
					ycarRotation.y += increaseRate*Time.deltaTime;
				}
				if (Input.GetMouseButtonUp(0)){
					current = State.STRAIGHT;
				}
				transform.localRotation = Quaternion.Euler(ycarRotation);
				Debug.Log(ycarRotation.y);
				if(transform.position.x < -100){
					current = State.FREE;
					transform.gameObject.AddComponent<Rigidbody>();
					Rigidbody rb = GetComponent<Rigidbody>();
				//transform.Translate(Vector3.forward*freeVelocity*Time.deltaTime);
				rb.velocity = transform.forward * freeVelocity;
				rb.mass=mass;
				rb.drag=drag;
				}
				break; 

			case State.FREE:
				Debug.Log("FREE");
				
				break;
		}		
		
	}
}
