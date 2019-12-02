using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour {
	public GameObject AnimalsHappy,AnimalsSad; 
	public GameObject Target1, Target2, Target3;
	public bool isGOHit = false;
	// Use this for initialization
	bool isAnimationRun = false;
	void Start () {
		AnimalsHappy.SetActive (false);
		AnimalsSad.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
		if(isGOHit == true){
			isGOHit = false;
			AnimalsHappy.SetActive (true);
			AnimalsSad.SetActive (false);
			StartCoroutine(HideAnimal());

		}
		if(isAnimationRun == false){
			isAnimationRun = true;
			StartCoroutine(TargetAnimation());
		}
	}


	IEnumerator HideAnimal() {
		FireButton.intScore++;
		yield return new WaitForSeconds(2);
		gameObject.SetActive (false);
	}

	IEnumerator TargetAnimation() {
		Target1.SetActive (true);
		Target2.SetActive (false);
		Target3.SetActive (false);
		yield return new WaitForSeconds(FireButton.TargetSpeed);
		Target1.SetActive (false);
		Target2.SetActive (true);
		Target3.SetActive (false);
		yield return new WaitForSeconds(FireButton.TargetSpeed);
		Target1.SetActive (false);
		Target2.SetActive (false);
		Target3.SetActive (true);
		yield return new WaitForSeconds(FireButton.TargetSpeed);
		StartCoroutine(TargetAnimation());

	}

}
