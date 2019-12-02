using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickGirl : MonoBehaviour {
	public static string StaticGirlName;
	public string GirlName;
	// Update is called once per frame
	void OnMouseOver () {
		if (Input.GetMouseButtonDown (0)) { 
			//this.gameObject.SetActive (false);
			StaticGirlName = GirlName;
		}
	}
}
