using UnityEngine;
using System.Collections;

public class SideRoomCameraResetRolloverScript : MonoBehaviour {

	public GameObject cameraManager;
	SideRoomCameraScript cameraScript;
	
	public Transform ballLockWall;
	
	void Start() {
		cameraScript = cameraManager.GetComponent<SideRoomCameraScript>();
		
		if(ballLockWall == null) {
			Debug.LogError("No ballLockWall!");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Ball") {
			BallRoomTrackerScript s = other.GetComponent<BallRoomTrackerScript>();
			s.inSideRoom = false;
			cameraScript.ResetCamera();
			
			BallLockWallScript blws = ballLockWall.GetComponent<BallLockWallScript>();
			blws.LowerWall();
			
			ToastManagerScript.Instance.ShowToast(ToastManagerScript.Instance.texBreedingGround);
			
		}
	}
}
