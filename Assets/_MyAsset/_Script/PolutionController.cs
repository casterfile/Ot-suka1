using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolutionController : MonoBehaviour {
	public GameObject GO_Stage1, GO_Stage2,GO_Stage3;
	// Use this for initialization
	void Start () {
		GO_Stage1.SetActive (false);
		GO_Stage2.SetActive (false);
		GO_Stage3.SetActive (false);

		if(Tutorial.currentStage == 1){
			GO_Stage1.SetActive (true);
			GO_Stage2.SetActive (false);
			GO_Stage3.SetActive (false);
		}
		else if(Tutorial.currentStage == 2){
			GO_Stage1.SetActive (true);
			GO_Stage2.SetActive (true);
			GO_Stage3.SetActive (false);
		}
		else if(Tutorial.currentStage == 3){
			GO_Stage1.SetActive (true);
			GO_Stage2.SetActive (true);
			GO_Stage3.SetActive (true);
		}
	}
	
//	// Update is called once per frame
//	void Update () {
//		
//	}
}
