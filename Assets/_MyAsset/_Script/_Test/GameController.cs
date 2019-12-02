using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text Timer, Score;
	private GameObject G1_Blash;
	float Delay = 1.8f;
	public Camera m_MainCamera;
	public GameObject ch1,ch2,ch3,ch4,ch5,ch6;

	public static bool isTreatment = false, isAnimalTargeted = false, isFire = false;
	int intScore = 0;
	float timeLeft = 60.0f;
	// Use this for initialization
	GameObject[] countAnimals;

	void Start () {
		


		isTreatment = false; 
		intScore = 0;
		timeLeft = 60.0f;

		G1_Blash = GameObject.Find ("Scene_02_Character_1_Blash");

		foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
		{
			if(gameObj.name == "Scene_02_Character_1_Blash")
			{
				gameObj.SetActive (false);
			}
		}

		ch1 = GameObject.Find ("Character_1");
		ch2 = GameObject.Find ("Character_2");
		ch3 = GameObject.Find ("Character_3");
		ch4 = GameObject.Find ("Character_4");
		ch5 = GameObject.Find ("Character_5");
		ch6 = GameObject.Find ("Character_6");

		ch1.SetActive (true);
		ch2.SetActive (true);
		ch3.SetActive (true);
		ch4.SetActive (true);
		ch5.SetActive (true);
		ch6.SetActive (true);
	}


	
	// Update is called once per frame
	void FixedUpdate() {
		//countAnimals = GameObject.FindGameObjectsWithTag("Counting");
		//GameScore(countAnimals.Length);



//		RaycastHit hit;
//		Ray landingRay = new Ray (m_MainCamera.transform.position, m_MainCamera.transform.forward);// Vector3.forward
//		if (Physics.Raycast (landingRay, out hit, 30)) {
////			print (hit.collider.tag); 
//			if (hit.collider.tag == "Animals") {
//				isAnimalTargeted = true;
//				if (isTreatment == true) {
//
//					if (hit.collider.tag == "Animals") {
//						isCount = false;
//						StartCoroutine (FuncReactAnimal (hit.collider.gameObject));
//						StartCoroutine (FuncCureAnimation ());
//
//					}
//				}
//			} else {
//				isAnimalTargeted = true;
//				if (isTreatment == true) {
//					StartCoroutine (FuncReactAnimalMiss ());
//				}
//			}
//		}
//		else {
//			if (isTreatment == true) {
//				StartCoroutine (FuncReactAnimalMiss ());
//			}
//		}


		timeLeft -= Time.deltaTime;
		int timeTemp = Mathf.RoundToInt (timeLeft);
		if(timeTemp >= 10)
		{
			Timer.text = "00:" + timeTemp;
		}else if(timeTemp < 10 && timeTemp >= 0){
			Timer.text = "00:0" + timeTemp;
		}

		if(timeTemp < 0 || timeTemp < 1){
			//Timer.text = "00:0" + timeTemp;
			//Application.LoadLevel("Scene_04");
		}

		if(intScore == 3){
			//Application.LoadLevel("Scene_03");
		}
	}
		
	bool isCount = false;
	IEnumerator FuncReactAnimal(GameObject Animal)
	{
		
		if(isCount == false){
			intScore++;
//			print ("intScore ="+ intScore);
		}
		isCount = true;

		GameObject Animal1 = Animal.transform.GetChild (0).gameObject;
		GameObject Animal2 = Animal.transform.GetChild (1).gameObject;

		yield return new WaitForSeconds(1.0f);


		Animal1.SetActive (false);
		Animal2.SetActive (true);
		yield return new WaitForSeconds(Delay);
//		Destroy(Animal);
		Animal.SetActive(false);



		isTreatment = false;
	}

	void funcCount(){
		intScore++;
		print ("intScore ="+ intScore);
	}

	IEnumerator FuncReactAnimalMiss()
	{


		yield return new WaitForSeconds(1.0f);
		yield return new WaitForSeconds(Delay);
		isTreatment = false;
	}

	IEnumerator FuncCureAnimation()
	{
		SwipeGameController.CureAnimation.SetActive (true);
		yield return new WaitForSeconds(1.30f);
		SwipeGameController.CureAnimation.SetActive (false);

	}

	void GameScore(int localScore){
		localScore =  6 - localScore;

		Score.text = "000"+localScore;
	}


		
}
