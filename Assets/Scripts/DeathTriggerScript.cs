using UnityEngine;
using System.Collections;

public class DeathTriggerScript : MonoBehaviour {
	
	public GameObject ballObject;
	public Transform ballSpawner;
	
	int extraLives = 3;
	
	// Use this for initialization
	void Start () {
		Instantiate(ballObject, ballSpawner.position, ballSpawner.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Ball") {
			Destroy (other);
			extraLives--;
			Instantiate(ballObject, ballSpawner.position, ballSpawner.rotation);
			
			if(extraLives == 0) {
				Application.LoadLevel("GameOver");
			}
		}
	}
	
}
