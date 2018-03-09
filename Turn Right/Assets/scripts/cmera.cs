using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmera : MonoBehaviour {

	GameObject car;
	Vector3 cam_offset;

	// Use this for initialization
	void Start () {
		car = GameObject.Find("Cube");
		cam_offset = new Vector3(0,2,-8);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = car.transform.position + cam_offset;
	}
}
