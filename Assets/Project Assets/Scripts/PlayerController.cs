using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jump;


	public GameObject[] endprops;
	public GameObject[] score;
	public int count = 0;
	float maxRange;
	RaycastHit hit;

	AudioSource pickup;
	AudioSource death;

	private float nextfire;
	private float firerate = 0.1f;

	private MeshRenderer playermesh;
	private Rigidbody rb;

	private int levelvar;
	private int leveloffset;
	private float highscore;

	private float h;
	private float v;
	


	void Start()
	{	
		maxRange = transform.lossyScale.x / 1.8f;


		endprops = GameObject.FindGameObjectsWithTag("EndMenu");

		foreach (GameObject respawn in endprops) {
			respawn.SetActive(false);
		}

		score = GameObject.FindGameObjectsWithTag("Points");

		foreach (GameObject scorer in score) {
			Text pointer = scorer.GetComponent<Text>();
			pointer.text = "Score: ";
		}

		rb = GetComponent<Rigidbody>();
		playermesh = GetComponent<MeshRenderer>();
		AudioSource[] audios = GetComponents<AudioSource>();
		pickup = audios[0];
		death = audios[1];
	}
	



	void FixedUpdate()	{

		if (SystemInfo.deviceType == DeviceType.Desktop) {
		
			h = Input.GetAxis ("Horizontal");
		} else {
			h = Input.acceleration.x;
			if(h > 0.5) h=1;
			else if (h < -0.5) h=-1;
		}

		v = 0.0f;
	
		Vector3 ground1 = new Vector3 (transform.position.x, transform.position.y - 10f, transform.position.z );
		Vector3 ground2 = new Vector3 (transform.position.x - 10f, transform.position.y - 10f, transform.position.z );
		Vector3 ground3 = new Vector3 (transform.position.x + 10f, transform.position.y - 10f, transform.position.z );


		if(Physics.Raycast(transform.position, (ground1 - transform.position), out hit, maxRange))
		{
			if(hit.collider != null)
			{
				if (Input.GetButton ("Fire1")) {
					nextfire = Time.time + firerate;
					v = jump;
				}

			}
		}

		if(Physics.Raycast(transform.position, (ground2 - transform.position), out hit, maxRange))
		        {

			if(hit.collider != null)
			{
				if (Input.GetButton ("Fire1") && Time.time > nextfire) {
					nextfire = Time.time + firerate;
					v = jump/3;
				}

			}

		}

		if(Physics.Raycast(transform.position, (ground3 - transform.position), out hit, maxRange))
		{

			if(hit.collider != null)
			{
				if (Input.GetButton ("Fire1") && Time.time > nextfire) {
					nextfire = Time.time + firerate;
					v = jump/3;
				}
				
			}

		}
		if (rb.velocity.magnitude > 10)
			h = 0;
		Vector3 movement = new Vector3 (h, v, 0.0f);
		rb.AddForce (movement * speed * Time.deltaTime);		
	}


	
	void OnTriggerEnter (Collider other) {
		if(other.gameObject.tag == "Coin" )
		{
			pickup.Play();
			other.gameObject.SetActive(false);
			count = count + 10;

			foreach (GameObject scorer in score) {
				Text pointer = scorer.GetComponent<Text>();
				pointer.text = "Score: " + count;
			}

		}

		else if(other.gameObject.tag == "Death" )
		{
			death.Play();
			playermesh.enabled = false;

			foreach (GameObject respawn in endprops) {
				respawn.SetActive(true);
			}
		}

		else if(other.gameObject.tag == "Won" )
		{

			playermesh.enabled = false;
			levelvar = PlayerPrefs.GetInt("savedLevel");
			highscore = PlayerPrefs.GetFloat("HighScore");

			highscore = highscore + count;
			leveloffset = Application.loadedLevel;
			levelvar = leveloffset;

			PlayerPrefs.SetInt ("savedLevel", levelvar);
			PlayerPrefs.SetFloat ("HighScore", highscore);
			PlayerPrefs.Save();
			Application.LoadLevel(leveloffset + 1);
			}
	}
}
