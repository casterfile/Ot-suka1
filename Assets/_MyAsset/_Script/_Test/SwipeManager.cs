

using UnityEngine;
using System.Collections;
public class SwipeManager : MonoBehaviour 
{
	public string NameScene;
	public bool isLeft; 
	private Vector2 initialPos ;
	void Update () 
	{
		if( Input.GetMouseButtonDown(0) )
		{
			initialPos = Input.mousePosition;
		}
		if( Input.GetMouseButtonUp(0))
		{       
			Calculate(Input.mousePosition);
		}
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
						Application.LoadLevel(NameScene);
					}

				}
				else
				{
					Debug.Log("Right");
					if(isLeft == false){
						Application.LoadLevel(NameScene);
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
				}
			}
		}
	}
}