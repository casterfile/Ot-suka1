using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReact : MonoBehaviour {
	public GameObject Parents;
	private AudioSource CuredMusic;
	// Use this for initialization
	void Start () {
		CuredMusic = GameObject.Find("CuredMusic").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Ball")
		{
			CuredMusic.Play(0);
			Parents.gameObject.GetComponent<AnimalController>().isGOHit = true;
		}
	}
}
