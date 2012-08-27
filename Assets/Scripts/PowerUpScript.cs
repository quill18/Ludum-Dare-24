using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	
	float rotationSpeed = 90f;
	Light myLight;
	float lightIntensity;
	
	// Use this for initialization
	void Start () {
		myLight = transform.Find("Point light").light;
		lightIntensity = myLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
		myLight.intensity = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup * 2)) * lightIntensity;
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.rigidbody.tag == "Ball") {
			Destroy (gameObject);
		}
	}
}
