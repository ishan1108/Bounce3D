using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	private int clevel;
	private int LevelOffset;

	// Use this for initialization
	void Start () {
		LevelOffset = Application.loadedLevel;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick () {
		clevel = PlayerPrefs.GetInt("savedLevel");
		Application.LoadLevel(clevel + LevelOffset);
	}
}
