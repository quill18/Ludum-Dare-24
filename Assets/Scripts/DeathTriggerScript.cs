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
			KillBall(other.gameObject);
			
			GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
			
			if(balls.Length <= 1) {
				LoseLife();
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
	
	public void ExplodeAllBalls() {
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
		foreach(GameObject ball in balls) {
			// TODO: Make an explosion graphic here.
			
			KillBall (ball);
			
		}
		
		LoseLife();		
	}
	
	void LoseLife() {
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
	
	void KillBall(GameObject ball) {
		BallColorScript bcs = ball.GetComponent<BallColorScript>();
		bcs.MakeEvolvedColor();
		
		Destroy (ball);
		
		audio.Play();
	}
	
	
}
