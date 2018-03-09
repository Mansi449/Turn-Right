using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("move", 1f);
	}

	void move() {
		GetComponent<Rigidbody>().velocity = new Vector3(20, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
