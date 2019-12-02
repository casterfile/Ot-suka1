using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningController : MonoBehaviour {
	public static bool isMarkerOn = false;
	public GameObject Scanning, FinishScan, Scene_01_Button; 
	// Use this for initialization
	void Start () {
		Tutorial.currentStage = 1;
		isMarkerOn = false;
		Scanning.SetActive (true);
		FinishScan.SetActive (false);
		Scene_01_Button.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (isMarkerOn == false) {
			Scanning.SetActive (true);
			FinishScan.SetActive (false);
			Scene_01_Button.SetActive (false);
		} else {
			Scanning.SetActive (false);
			FinishScan.SetActive (true);
			Scene_01_Button.SetActive (true);
		}
	}
}
