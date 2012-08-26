using UnityEngine;
using System.Collections;

public class SideRoomCameraResetRolloverScript : MonoBehaviour {

	public GameObject cameraManager;
	SideRoomCameraScript cameraScript;
	
	void Start() {
		cameraScript = cameraManager.GetComponent<SideRoomCameraScript>();
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Ball") {
			BallRoomTrackerScript s = other.GetComponent<BallRoomTrackerScript>();
			s.inSideRoom = false;
			cameraScript.ResetCamera();
		}
	}
}
