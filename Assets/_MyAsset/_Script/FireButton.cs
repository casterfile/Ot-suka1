using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

using System.Security.Cryptography;
using System.Text;

public class FireButton : MonoBehaviour {
	private Text Timer, Score;
	private GameObject CureAnimation;
	private GameObject LabelStage1,LabelStage2,LabelStage3;
	private GameObject POPStage1,POPStage2,POPStage3;
	private bool isStage1,isStage2,isStage3;

//	private GameObject Animal1,Animal2,Animal3,Animal4,Animal5,Animal6,Animal7,Animal8,Animal9,Animal10,Animal11,Animal12,Animal13,Animal14,Animal15;
	public GameObject Animals_Stage1, Animals_Stage2,Animals_Stage2_1,Animals_Stage2_2,Animals_Stage3,Animals_Stage3_1,Animals_Stage3_2;
	public static bool isTreatment = false, isAnimalTargeted = false, isFire = false;

	public static int intScore = 0, ScoreChanges, StageCount1 = 5, StageCount2 = 10, StageCount3 = 15;
	float timeLeft = 60.0f;
	public static float TargetSpeed = 0.3f;


	public GameObject BallLocation;
	public GameObject BalThraw,StaticBall;


	private Vector2 initialPos ;
	public bool isLeft; 

	private bool isFireNow = false;
	int RanNumber;

	private AudioSource StageClearedMusic;

	void AnimalStage(){
		if(Tutorial.currentStage == 1){
			Animals_Stage1.SetActive (true);
			if(RanNumber == 1){
				Animals_Stage2.SetActive (false);
			}else if(RanNumber == 2){
				Animals_Stage2_1.SetActive (false);
			}else{
				Animals_Stage2_2.SetActive (false);
			}

			if(RanNumber == 1){
				Animals_Stage3.SetActive (false);
			}else if(RanNumber == 2){
				Animals_Stage3_1.SetActive (false);
			}else{
				Animals_Stage3_2.SetActive (false);
			}

		}else if(Tutorial.currentStage == 2){
			Animals_Stage1.SetActive (false);

			if(RanNumber == 1){
				Animals_Stage2.SetActive (true);
			}else if(RanNumber == 2){
				Animals_Stage2_1.SetActive (true);
			}else{
				Animals_Stage2_2.SetActive (true);
			}

			if(RanNumber == 1){
				Animals_Stage3.SetActive (false);
			}else if(RanNumber == 2){
				Animals_Stage3_1.SetActive (false);
			}else{
				Animals_Stage3_2.SetActive (false);
			}
		}else if(Tutorial.currentStage == 3){
			Animals_Stage1.SetActive (false);

			if(RanNumber == 1){
				Animals_Stage2.SetActive (false);
			}else if(RanNumber == 2){
				Animals_Stage2_1.SetActive (false);
			}else{
				Animals_Stage2_2.SetActive (false);
			}

			if(RanNumber == 1){
				Animals_Stage3.SetActive (true);
			}else if(RanNumber == 2){
				Animals_Stage3_1.SetActive (true);
			}else{
				Animals_Stage3_2.SetActive (true);
			}
		}
	}


	void Start () {
		StageClearedMusic = GameObject.Find("StageClearedMusic").GetComponent<AudioSource>();

		RanNumber = Random.Range(1,4);
		//Tutorial.currentStage = 1;
		isStage1 = isStage2 = isStage3 = false;

		//BalThraw.SetActive (false);
		CureAnimation = GameObject.Find ("CureAnimation");
		Timer = GameObject.Find ("ScoreTime/TIME").GetComponent<Text>();
		Score = GameObject.Find ("ScoreTime/Treated").GetComponent<Text>();

		LabelStage1 = GameObject.Find ("LabelStage1");
		LabelStage2 = GameObject.Find ("LabelStage2");
		LabelStage3 = GameObject.Find ("LabelStage3");

		POPStage1 = GameObject.Find ("POPStage1");
		POPStage2 = GameObject.Find ("POPStage2");
		POPStage3 = GameObject.Find ("POPStage3");



		CureAnimation.SetActive (false);
		LabelStage1.SetActive (true); LabelStage2.SetActive (false); LabelStage3.SetActive (false);
		POPStage1.SetActive (false); POPStage2.SetActive (false); POPStage3.SetActive (false);
		ScoreChanges = intScore;

		LabelStageControl(Tutorial.currentStage);
		AnimalStage ();
		//StartCoroutine(AnimationStage());
	}


	void Update(){
		

		timeLeft -= Time.deltaTime;
		int timeTemp = Mathf.RoundToInt (timeLeft);
		if(timeTemp >= 10)
		{
			Timer.text = "" + timeTemp;
		}else if(timeTemp < 10 && timeTemp >= 0){
			Timer.text = "" + timeTemp;
		}

		if(timeTemp < 0 || timeTemp < 1){
			//Timer.text = "00:0" + timeTemp;
			Application.LoadLevel("Scene_03");
		}

		if(ScoreChanges != intScore){
			ScoreChanges = intScore;
			StartCoroutine(AnimationCure());
		}

		int ScoreCalulate = 0;
		if (Tutorial.currentStage == 1) {
			ScoreCalulate = StageCount1 - intScore;
		}else if(Tutorial.currentStage == 2){
			ScoreCalulate = StageCount2 - intScore;
		}else if(Tutorial.currentStage == 3){
			ScoreCalulate = StageCount3 - intScore;
		}

		Score.text = ""+ScoreCalulate;

		if(ScoreCalulate == 0){
			if (Tutorial.currentStage == 1) {
				StartCoroutine(TutorialCheck(2));
			}else if(Tutorial.currentStage == 2){
				StartCoroutine(TutorialCheck(3));
			}else if(Tutorial.currentStage == 3){
				StartCoroutine(TutorialCheck(4));
			}
			intScore = 0;
		}




	}

	IEnumerator TutorialCheck(int CurrentStage) {
		Tutorial.currentStage = CurrentStage;
		StartCoroutine(AnimationStage());

		yield return new WaitForSeconds(5.0f);
		if (Tutorial.currentStage == 4) {
			Application.LoadLevel("Scene_03");
		} else {
			Application.LoadLevel("Scene_01_Tutorial");
		}

	}

	void LabelStageControl(int Stage){
		if(Stage == 1){
			LabelStage1.SetActive(true);
			LabelStage2.SetActive(false);
			LabelStage3.SetActive(false);
		}else if(Stage == 2){
			LabelStage1.SetActive(false);
			LabelStage2.SetActive(true);
			LabelStage3.SetActive(false);
		}else if(Stage == 3){
			LabelStage1.SetActive(false);
			LabelStage2.SetActive(false);
			LabelStage3.SetActive(true);
		}
	}
		

	public void FireNow(){
		if(isFireNow == false){
			isFireNow = true;
//			BalThraw.transform.position = new Vector3(0, 0, 0);
			StartCoroutine(fallingObject());

		}
	}

	IEnumerator fallingObject() {
		StaticBall.SetActive (false);
		Fire();
		yield return new WaitForSeconds(2);
		isFireNow = false;
		StaticBall.SetActive (true);
	}

	IEnumerator AnimationCure() {
		CureAnimation.SetActive (true);
		yield return new WaitForSeconds(1.30f);
		CureAnimation.SetActive (false);
	}

	IEnumerator AnimationStage(){
		yield return new WaitForSeconds(1.30f);
		if(Tutorial.currentStage == 2 && isStage1 == false){
			isStage1 = true;
			timeLeft = 60;
			POPStage1.SetActive(true);
			POPStage2.SetActive(false);	
			POPStage3.SetActive(false);	
			StageClearedMusic.Play(0);
			yield return new WaitForSeconds(1.30f);
			POPStage1.SetActive(false);	
			POPStage2.SetActive(false);	
			POPStage3.SetActive(false);
		}else if(Tutorial.currentStage == 3 && isStage2 == false){
			isStage2 = true;
			timeLeft = 60;
			POPStage1.SetActive(false);
			POPStage2.SetActive(true);	
			POPStage3.SetActive(false);	
			StageClearedMusic.Play(0);
			yield return new WaitForSeconds(1.30f);
			POPStage1.SetActive(false);	
			POPStage2.SetActive(false);	
			POPStage3.SetActive(false);
		}else if(Tutorial.currentStage == 4  && isStage3 == false){
			isStage3 = true;
			timeLeft = 60;
			POPStage1.SetActive(false);	
			POPStage2.SetActive(false);	
			POPStage3.SetActive(true);	
			StageClearedMusic.Play(0);
			yield return new WaitForSeconds(1.30f);
			POPStage1.SetActive(false);	
			POPStage2.SetActive(false);	
			POPStage3.SetActive(false);
//			Application.LoadLevel("Scene_03");
		}

	}


	void Fire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			BalThraw,
			BallLocation.transform.position,
			BallLocation.transform.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);        
	}

	void Calculate(Vector3 finalPos)
	{
		float disX = Mathf.Abs(initialPos.x - finalPos.x);
		float disY = Mathf.Abs(initialPos.y - finalPos.y);
		if(disX>0 || disY>0)
		{
			if (disX > disY) 
			{
				if (initialPos.x > finalPos.x)
				{
					Debug.Log("Left");
					if(isLeft == true){

					}

				}
				else
				{
					Debug.Log("Right");
					if(isLeft == false){

					}
				}
			}
			else 
			{   
				if (initialPos.y > finalPos.y )
				{
					Debug.Log("Down");
				}
				else
				{
					Debug.Log("Up");
					FireNow ();

					//GameController.isTreatment = true;
				}
			}
		}
	}

}


