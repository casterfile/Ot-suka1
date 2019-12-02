using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour {
	public string NameScene;
	public AudioSource ClickMusic;
	void Start(){
		ClickMusic = GameObject.Find("ClickMusic").GetComponent<AudioSource>();
	}
	void OnMouseOver()
	{
		ClickMusic.Play(0);
		string isRegister = PlayerPrefs.GetString ("isRegister");
		if (isRegister == "YES") {
			Application.LoadLevel ("Scene_01_Tutorial");
		} else {
			Application.LoadLevel(NameScene);
		}

	}
}
