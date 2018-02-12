using UnityEngine;
using System.Collections;

public class RetryLevel : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void GotoMenu() {
		Application.LoadLevel (Application.loadedLevelName);
		
	}
}
