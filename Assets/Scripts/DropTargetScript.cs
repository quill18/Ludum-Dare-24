using UnityEngine;
using System.Collections;

public class DropTargetScript : MonoBehaviour {

	bool wasHit = false;
	
	void OnCollisionEnter(Collision collision) {
		if(!wasHit && collision.gameObject.tag == "Ball") {
			wasHit = true;
			transform.Translate(0, -2.9f, 0);	
		}
	}
	
	public void ResetTarget() {
		wasHit = false;
		transform.Translate(0, 2.9f, 0);	
	}
}
