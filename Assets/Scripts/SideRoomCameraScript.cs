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
	float transitionTimeLeft = 0;

	// Use this for initialization
	void Start () {
		mainCameraPosition = mainCamera.transform.position;
		mainCameraRotation = mainCamera.transform.rotation;
		sideCameraPosition = sideCamera.transform.position;
		sideCameraRotation = sideCamera.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
		transitionTimeLeft += Time.deltaTime;
		
		float t = (transitionTimeLeft - transitionTime) / transitionTime;
		
		if(t < 1f) {
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
	
	void OnTriggerEnter(Collider collider) {
		if(collider.tag == "Ball" ) {
			movingToSide = true;
		}
	}
}
