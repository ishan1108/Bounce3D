using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour {

	public int boost;
	private Rigidbody rb;

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			rb = other.gameObject.GetComponent<Rigidbody> ();
			rb.velocity = rb.velocity * boost;
			
		}
	}


}
