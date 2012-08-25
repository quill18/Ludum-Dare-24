using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {

	bool wasHit = false;
	
	void OnCollisionEnter(Collision collision) {
		if(!wasHit && collision.gameObject.tag == "Ball") {
			wasHit = true;
			transform.Translate(0, -2.9f, 0);	
		}
	}
}
