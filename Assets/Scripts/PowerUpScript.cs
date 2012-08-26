using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {
	
	float rotationSpeed = 90f;
	Light light;
	float lightIntensity;
	
	// Use this for initialization
	void Start () {
		light = transform.Find("Point light").light;
		lightIntensity = light.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
		light.intensity = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup * 2)) * lightIntensity;
	}
}
