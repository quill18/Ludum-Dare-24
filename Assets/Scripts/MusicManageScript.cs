using UnityEngine;
using System.Collections;

public class MusicManageScript : MonoBehaviour {
	
	public AudioClip[] songs;
	int currentSong = 2;
	
	void Start() {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(audio.isPlaying == false) {
			if(currentSong >= songs.Length)
				currentSong = 0;
			
			audio.clip = songs[ currentSong++ ];
			audio.Play ();
		}
	}
}
