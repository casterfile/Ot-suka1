using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
	private GameObject GO_tutorial_1,GO_tutorial_2,GO_tutorial_3;
	public static int currentStage = 1;
	private  GameObject LoadingPage;

	public AudioSource ClickMusic;
	// Use this for initialization
	void Start () {
		ClickMusic = GameObject.Find("ClickMusic").GetComponent<AudioSource>();

		//currentStage = 1;
		GO_tutorial_1 = GameObject.Find ("Tutorial_1");
		GO_tutorial_2 = GameObject.Find ("Tutorial_2");
		GO_tutorial_3 = GameObject.Find ("Tutorial_3");
		Stage ();

		LoadingPage = GameObject.Find ("LoadingPage");
		LoadingPage.SetActive (false);
	}

	private void Stage(){
		if(currentStage == 1){
			GO_tutorial_1.SetActive (true);
			GO_tutorial_2.SetActive (false);
			GO_tutorial_3.SetActive (false);
		}
		if(currentStage == 2){
			GO_tutorial_1.SetActive (false);
			GO_tutorial_2.SetActive (true);
			GO_tutorial_3.SetActive (false);
		}
		if(currentStage == 3){
			GO_tutorial_1.SetActive (false);
			GO_tutorial_2.SetActive (false);
			GO_tutorial_3.SetActive (true);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		if(currentStage >= 4){
//			LoadingPage.SetActive (true);
//			Application.LoadLevel("Scene_02_Game");
//		}
	}

	public void NextPage(){
		ClickMusic.Play(0);

		LoadingPage.SetActive (true);
		Application.LoadLevel("Scene_02_Game");
//		Stage ();
	}

}
