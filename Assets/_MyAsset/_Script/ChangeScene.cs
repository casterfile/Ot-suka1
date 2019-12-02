using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {
	private AudioSource ClickMusic;
	void Start(){
		ClickMusic = GameObject.Find("ClickMusic").GetComponent<AudioSource>();
	}
	// Update is called once per frame
	public void UpdateChangeScene (string NameScene) {
		ClickMusic.Play(0);
		Application.LoadLevel(NameScene);
	}

	public void ExitGame(){
		Application.Quit();
	}
}
