using UnityEngine;
using System.Collections;

public class RolloverScript : MonoBehaviour {
	
	float rotTriggered = 45f;
	float recoverRate = 180f;
	
	float rot = 0;
	
	// Update is called once per frame
	void Update () {
		if(rot > 0) {
			rot -= recoverRate * Time.deltaTime;
			transform.Find ("rotator").transform.Rotate(0, 0, -recoverRate * Time.deltaTime);
		}
		
			
	
	}
	
	void OnCollisionEnter(Collision collision) {
		if(rot <= 0 && collision.gameObject.tag == "Ball") {
			rot += rotTriggered;
			transform.Find ("rotator").transform.Rotate(0, 0, rotTriggered);
		}
	}
	
}
