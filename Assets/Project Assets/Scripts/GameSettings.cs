using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour {

	private int levelvar;
	private float highscore;


	// Use this for initialization
	void Start () {

		levelvar = PlayerPrefs.GetInt("savedLevel");
		highscore = PlayerPrefs.GetFloat ("HighScore");

		if (highscore == 0) {

			PlayerPrefs.SetInt ("savedLevel", 1);
			PlayerPrefs.SetFloat ("HighScore", 0.0f);
			levelvar = PlayerPrefs.GetInt ("savedLevel");
			highscore = PlayerPrefs.GetFloat ("HighScore");
		}

		UILabel subtitle = GameObject.Find("High Score").GetComponent<UILabel>();
		subtitle.text = "Score: " + highscore;
			
		UILabel leveltext = GameObject.Find("Level Count").GetComponent<UILabel>();
		leveltext.text = "Current Level: " + levelvar;
	
	}

}
