using UnityEngine;
using System.Collections;

public class TiltScript : MonoBehaviour {
	
	float tiltScore  = 0;
	float tiltFactor = .5f;
	
	float shakeCurrent = 0;
	float shakeMax = 2f;
	float shakeDamp = 10f;
	
	Vector3 realPos;
	
	void Start() {
		realPos = transform.position;
	}
	
	void Update() {
		if(tiltScore > 0)
			tiltScore -= Time.deltaTime;
		
		if(tiltScore > 1f) {
			Debug.Log ("TILT ALARM");
		}
		
		if(Input.GetButtonDown("Tilt")) {
			Debug.Log ("Tilt!");
			tiltScore += tiltFactor; 
			shakeCurrent = shakeMax;
			GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
			
			foreach(GameObject ball in balls) {
				BallTiltScript bts = ball.GetComponent<BallTiltScript>();
				bts.DoTilt();
			}
		}
		
		
		if(shakeCurrent > 0) {
			Vector3 pos = realPos;
			pos.x += Random.Range(-shakeCurrent, shakeCurrent);
			pos.y += Random.Range(-shakeCurrent, shakeCurrent);
			pos.z += Random.Range(-shakeCurrent, shakeCurrent);
			transform.position = pos;
			shakeCurrent -= shakeDamp * Time.deltaTime;
		}
	}
	

}
