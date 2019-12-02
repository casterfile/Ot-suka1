

using UnityEngine;
using System.Collections;
public class SwipeGameController : MonoBehaviour 
{
	public string NameScene;
	public bool isLeft; 
	private Vector2 initialPos ;
	private bool boolSwipeHit = false;
	private GameObject Ball,Ball_Attack;
	public static GameObject CureAnimation;

	void Start(){
		Ball = GameObject.Find ("Ball");
		Ball_Attack = GameObject.Find ("Ball_Attack");
		CureAnimation = GameObject.Find ("CureAnimation");
		//Ball_Attack.SetActive (false);
		CureAnimation.SetActive (false);
	}

	void FixedUpdate () 
	{
		if(boolSwipeHit == true){
			if( Input.GetMouseButtonDown(0) )
			{
				initialPos = Input.mousePosition;
			}
			if( Input.GetMouseButtonUp(0))
			{       
				Calculate(Input.mousePosition);
			}
		}

		if (GameController.isTreatment == true) {
			Ball.SetActive (false);
			Ball_Attack.SetActive (true);
		} else {
			Ball.SetActive (true);
			//Ball_Attack.SetActive (false);
		}
	}

	public void SwipeHit(){
//		if(GameController.isAnimalTargeted == true){
			boolSwipeHit = true;
//		print ("Hello world");
//		}
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
					Ball.SetActive (false);
					GameController.isTreatment = true;
					//boolSwipeHit = false;
				}
			}
		}
	}
}