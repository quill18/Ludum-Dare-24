using UnityEngine;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {
	
	int score = 0;
	public int Score {
		get {
			return score;
		}
	}
	
	static ScoreManagerScript instance = null;
	static public ScoreManagerScript Instance {
		get {
			if(instance == null) {
				GameObject go = new GameObject();
				instance = go.AddComponent<ScoreManagerScript>();
			}
			
			return instance;
		}
	}
	
	// Use this for initialization
	void Start () {
		if( instance == null ) 
			instance = this;
	}
	
	public void AddScore(int v) {
		score += v;
	}
	
	void OnGUI() {
		GUI.TextArea(new Rect(0, 0, 100, 100), "Score: " + score);
	}
	
}
