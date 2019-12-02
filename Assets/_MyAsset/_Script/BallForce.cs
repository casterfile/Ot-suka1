using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallForce : MonoBehaviour {

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		//rb.AddForce(transform.forward * thrust);
		//rb.AddForce(0, 0 , 5);
		//rb.drag = 1;
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Animals")
		{
			transform.position = new Vector3(0, 0, 0);
			gameObject.SetActive (false);
		}
	}
}
