using UnityEngine;
using System.Collections;

public class ScoreManagerScript : MonoBehaviour {
	
	public GUISkin guiSkin;
	public GameObject deathTrigger;
	DeathTriggerScript deathTriggerScript;
	
	int scoreMultiplier = 100;
	
	int nextExtraLife = 25000;
	
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
		
		deathTriggerScript = deathTrigger.GetComponent<DeathTriggerScript>();
	}
	
	public void AddScore(int v) {
		score += v * scoreMultiplier;
		
		if(score > nextExtraLife) {
			DeathTriggerScript.Instance.AddExtraLife();
			ToastManagerScript.Instance.ShowToast(ToastManagerScript.Instance.texExtraLife);
			
			if(nextExtraLife < 50000)
				nextExtraLife=50000;
			else
				nextExtraLife += 50000;
		}
	}
	
	public void AddBonus(int v) {
		bonus += v * scoreMultiplier;
	}
	
	void OnGUI() {
		GUI.skin = guiSkin;
		GUILayout.BeginArea( new Rect(0, 0, Screen.width, Screen.height) );
			GUILayout.BeginHorizontal();
				GUILayout.BeginVertical();
					GUILayout.FlexibleSpace();
					GUILayout.BeginVertical("Box");
						GUILayout.Label("Extra Lives: " + string.Format("{0:n0}", deathTriggerScript.ExtraLives));
						GUILayout.Label("Score: " + string.Format("{0:n0}", score));
						GUILayout.Label("Bonus: " + bonus + " x " + bonusMultiplier + " = " + (bonus*bonusMultiplier));
					GUILayout.EndVertical();
				GUILayout.EndVertical();
				GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
	
	public void IncreaseBonusMultiplier() {
		if(bonusMultiplier < 64) {
			bonusMultiplier *= 2;
		}
	}
	
	public void CashInBonus() {
		AddScore(bonus * bonusMultiplier);
		bonus = 0;
		bonusMultiplier = 1;
	}
	
}
