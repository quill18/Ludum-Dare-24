using UnityEngine;
using System.Collections;

public class HighScoresScript : MonoBehaviour {
	
	public  GUISkin skin;
	int numScores = 10;
	
	int[] scores;
	string[] names;
	int editableName=-1;
	
	// Use this for initialization
	void Start () {
		// Compare current score to high-scores list
		
		
		scores = new int[10];
		names = new string[10];
		
		for(int i=0; i < numScores; i++) {
			scores[i] = PlayerPrefs.GetInt("HighScore"+i, 0);
			names[i] = PlayerPrefs.GetString("HighScoreName"+i, "");
		}
		
		int s = PlayerPrefs.GetInt ("Score");
		PlayerPrefs.SetInt("Score", 0);
		string n = "";
		
		// Move everything down to fit the player, if needed
		for(int i=0; i < numScores; i++) {
			if( s > scores[i] ) {
				if(editableName == -1)
					editableName = i;
				
				PlayerPrefs.SetInt("HighScore"+i, s);
				PlayerPrefs.SetString("HighScoreName"+i, n);
				
				int st = scores[i];
				scores[i] = s;
				s = st;
				
				string nt = names[i];
				names[i] = n;
				n = nt;
			}
			
		}
	}
	
	void Update() {
		for(int i=0; i < numScores; i++) {
			PlayerPrefs.SetString("HighScoreName"+i, names[i]);
		}
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.skin = skin;
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
			GUILayout.BeginHorizontal();
				GUILayout.FlexibleSpace();
				GUILayout.BeginVertical();
		
				GUILayout.Label("HIGH SCORES");
		
				
				for(int i=0; i < numScores; i++) {
					GUILayout.BeginHorizontal();
			
					if(editableName != i) {
						GUILayout.Label(names[i], GUILayout.Width(100));
					}
					else {
						names[i] = GUILayout.TextField(names[i], 3, GUILayout.Width(100));
				
					}
					GUILayout.Label(scores[i].ToString());
					GUILayout.EndHorizontal();
				}
		
				if( GUILayout.Button("Play Again!") ) {
					for(int i=0; i < numScores; i++) {
						PlayerPrefs.SetString("HighScoreName"+i, names[i]);
					}
			
					PlayerPrefs.Save();
					Application.LoadLevel("levelWithMesh2");
				}
		
				GUILayout.EndVertical();
				GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}
