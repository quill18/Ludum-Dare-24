using UnityEngine;
using System.Collections;

public class DeathTriggerScript : MonoBehaviour {
	
	public Transform ballSpawner;
	BallSpawnerScript ballSpawnerScript;
	
	
	static DeathTriggerScript instance = null;
	static public DeathTriggerScript Instance {
		get {
			return instance;
		}
	}
	
	
	
	int extraLives = 3;
	public int ExtraLives {
		get {
			return extraLives;
		}
	}
	
	// Use this for initialization
	void Start () {
		instance = this;
		ballSpawnerScript = ballSpawner.GetComponent<BallSpawnerScript>();
	}
	
	public void AddExtraLife() {
		extraLives++;
	}
		
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Ball") {
			BallColorScript bcs = other.GetComponent<BallColorScript>();
			bcs.MakeEvolvedColor();
			
			Destroy (other.gameObject);
			
			GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
			
			if(balls.Length <= 1) {
				extraLives--;
				
				ScoreManagerScript.Instance.CashInBonus();
			
				if(extraLives == 0) {
					Application.LoadLevel("GameOver");
				}
				else {
					LifeResetAllObjects();
					ballSpawnerScript.SpawnBall();
				}
			}

		}
	}
	
	void LifeResetAllObjects() {
		GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		
		foreach (GameObject go in gos) {
			go.BroadcastMessage("LifeReset", SendMessageOptions.DontRequireReceiver);
		}
	}
	
	void TotalResetAllObjects() {
		GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		
		foreach (GameObject go in gos) {
			go.BroadcastMessage("LifeReset", SendMessageOptions.DontRequireReceiver);
			go.BroadcastMessage("TotalReset", SendMessageOptions.DontRequireReceiver);
		}
	}
	
	
}
