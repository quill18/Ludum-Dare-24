using UnityEngine;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {
	
	int score = 0;
	public int Score {
		get {
			return score;
		}
	}
	
	int bonus = 0;
	int bonusMultiplier = 1;
	
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
		GUILayout.BeginArea( new Rect(0, 0, Screen.width, Screen.height) );
			GUILayout.BeginVertical();
				GUILayout.FlexibleSpace();
				GUILayout.BeginHorizontal();
					GUILayout.FlexibleSpace();
					GUILayout.TextArea("Score: " + score);
					GUILayout.TextArea("Bonus: " + bonus + " x " + bonusMultiplier + " = " + (bonus*bonusMultiplier));
					GUILayout.FlexibleSpace();
				GUILayout.EndHorizontal();
			GUILayout.EndVertical();
		GUILayout.EndArea();
	}
	
	public void IncreaseBonusMultiplier() {
		if(bonusMultiplier < 64) {
			bonusMultiplier *= 2;
		}
	}
	
	public void CashInBonus() {
		score += bonus * bonusMultiplier;
		bonus = 0;
		bonusMultiplier = 1;
	}
	
}
