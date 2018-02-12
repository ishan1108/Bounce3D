using UnityEngine;
using System.Collections;

public class WaitControl : MonoBehaviour {

	private int LevelOffset;

	void Start() {
		LevelOffset = Application.loadedLevel;
		StartCoroutine(waiting());
	}
	
	IEnumerator waiting() {
		yield return new WaitForSeconds(2);
		Application.LoadLevel(LevelOffset+1);

	}
}
