using UnityEngine;
using System.Collections;

public class SideRoomCameraScript : MonoBehaviour {
	
	public GameObject mainCamera;
	public GameObject sideCamera;
	
	Vector3 mainCameraPosition;
	Vector3 sideCameraPosition;
	Quaternion mainCameraRotation;
	Quaternion sideCameraRotation;
	
	bool movingToSide = false;
	
	public float transitionTime = 2f;
	float transitionTimePassed = 9999f;

	// Use this for initialization
	void Start () {
		mainCameraPosition = mainCamera.transform.position;
		mainCameraRotation = mainCamera.transform.rotation;
		sideCameraPosition = sideCamera.transform.position;
		sideCameraRotation = sideCamera.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		if(transitionTimePassed < transitionTime) {
			transitionTimePassed += Time.deltaTime;
			float t = (transitionTimePassed ) / transitionTime;
			
			if(movingToSide) {
				Camera.main.transform.position = Vector3.Lerp (mainCameraPosition, sideCameraPosition, t);
				Camera.main.transform.rotation = Quaternion.Lerp (mainCameraRotation, sideCameraRotation, t);
			}
			else {
				Camera.main.transform.position = Vector3.Lerp (sideCameraPosition, mainCameraPosition, t);
				Camera.main.transform.rotation = Quaternion.Lerp (sideCameraRotation, mainCameraRotation, t);
			}
		}
	}
	
	public void ResetCamera() {
		if(movingToSide) {
			transitionTimePassed = 0;
			movingToSide = false;
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if(collider.tag == "Ball" && movingToSide == false ) {
			BallRoomTrackerScript s = collider.GetComponent<BallRoomTrackerScript>();
			s.inSideRoom = true;
			
			GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
			
			ToastManagerScript.Instance.ShowToast(ToastManagerScript.Instance.texGeographicIsolation);
			
			if (balls.Length > 1)
				return; // Don't do camera zoom if we're in a multi-ball situation.
			
			/*foreach (GameObject ball in balls) {
				s = ball.GetComponent<BallRoomTrackerScript>();
				if(!s.inSideRoom)
					return;	// At least one ball not in side room, abort camera move.
			}*/
			
			transitionTimePassed = 0;
			movingToSide = true;
		}
	}
}
