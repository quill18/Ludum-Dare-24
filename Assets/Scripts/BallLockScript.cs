using UnityEngine;
using System.Collections;

public class BallLockScript : MonoBehaviour {

	public Transform ballSpawner;
	BallSpawnerScript ballSpawnerScript;
	
	public Transform ballLockWall;
	
	int lockedBalls = 0;
	float ballSpawnDelay = .3f;
	float ballSpawnDelayRemaining = .3f;

	// Use this for initialization
	void Start () {
		ballSpawnerScript = ballSpawner.GetComponent<BallSpawnerScript>();	
	}
	
	void FixedUpdate() {
		if(lockedBalls < 0) {
			
			ballSpawnDelayRemaining -= Time.deltaTime;
			
			if(ballSpawnDelayRemaining <= 0) {
				lockedBalls++;
				ballSpawnDelayRemaining = ballSpawnDelay;
				ballSpawnerScript.SpawnBall(true);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.A)) {
			// MULTI BALL CHEAT!
			DoMultiball();			
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Ball") {
			Destroy (other.gameObject);
			lockedBalls++;
			
			if(lockedBalls < 3) {
				ballSpawnerScript.SpawnBall();
			}
			else {
				DoMultiball();
			}
		}
	}
	
	void DoMultiball() {
		lockedBalls = -3;
		ballSpawnDelayRemaining = ballSpawnDelay;
		
		BallLockWallScript blws = ballLockWall.GetComponent<BallLockWallScript>();
		blws.TotalReset();
		
		ToastManagerScript.Instance.ShowToast(ToastManagerScript.Instance.texMultiBall);
	}
	
	public void TotalReset() {
		lockedBalls = 0;
	}
}
