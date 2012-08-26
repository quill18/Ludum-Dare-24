using UnityEngine;
using System.Collections;

public class BallLockWallScript : MonoBehaviour {

	
	/*void OnCollisionEnter(Collision collision) {
		if(collision.rigidbody.tag=="Ball") {
			LowerWall();
		}
	}*/
	
	public void LowerWall() {
		transform.Translate(0, -3f, 0);
	}
	
	public void TotalReset() {
		Vector3 pos = transform.position;
		pos.y = 0;
		transform.position = pos;
	}
}
