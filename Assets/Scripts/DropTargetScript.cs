using UnityEngine;
using System.Collections;

public class DropTargetScript : MonoBehaviour {

	bool wasHit = false;
	bool resetOnNewLife = true;
	
	void OnCollisionEnter(Collision collision) {
		if(!wasHit && collision.gameObject.tag == "Ball") {
			wasHit = true;
			transform.Translate(0, -2.9f, 0);	
		}
	}
	
	public void ResetTarget() {
		wasHit = false;
		Vector3 pos = transform.position;
		pos.y = 0;
		transform.position = pos;
	}
	
	public void LifeReset() {
		if(resetOnNewLife)
			ResetTarget();
	}
	
	public void TotalReset() {
		ResetTarget();
	}
}
