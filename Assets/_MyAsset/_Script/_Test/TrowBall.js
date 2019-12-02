#pragma strict
  
 var power = 1000.0;
  
 private var startPos  : Vector3;
 var slX;
 var slY;
 var slZ;
function Start(){
	slX = gameObject.transform.localPosition.x;
	slY = gameObject.transform.localPosition.y;
	slZ = gameObject.transform.localPosition.z;
}

function OnMouseDown() {
	 startPos = Input.mousePosition;
	 startPos.z = transform.position.z - Camera.main.transform.position.z;
	 startPos = Camera.main.ScreenToWorldPoint(startPos);
}
  
 function OnMouseUp() {
     var endPos = Input.mousePosition;
     endPos.z = transform.position.z - Camera.main.transform.position.z;
     endPos = Camera.main.ScreenToWorldPoint(endPos);
  
     var force = endPos - startPos;
     force.z = force.magnitude;
     force.Normalize();
  
     GetComponent.<Rigidbody>().AddForce(force * power);
     ReturnBall();
 }
  
 function ReturnBall() {
     yield WaitForSeconds(4.0);
     transform.localPosition = new Vector3(slX,slY,slZ);//Vector3.zero;
     GetComponent.<Rigidbody>().velocity = Vector3.zero;
 }