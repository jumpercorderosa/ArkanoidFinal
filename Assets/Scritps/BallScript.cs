using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {

	int count_blocks = 0;
	public float velocidade;
	public GameObject player; 
	public Sprite destroyed_1;
	public Sprite destroyed_2;
	public AudioSource audio_ping;
	public AudioSource audio_loose;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().mass = 7;
		GetComponent<Rigidbody2D>().gravityScale = 0.0003f;
		GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidade;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//how to get the ball to bounce off the paddles at an angle
	float hitFactor(Vector2 ballPos, Vector2 playerPos, float playerWidht) {

		// ascii art:
		// ||  1 <- at the dir side of the player
		// ||
		// ||  0 <- at the middle of the player
		// ||
		// || -1 <- at the left side of the player

		return (ballPos.x - playerPos.x) / playerWidht;
	}

	void OnCollisionEnter2D(Collision2D c) {

		print("TAG [" + gameObject.tag + "]");
		print("C_TAG [" + c.gameObject.tag + "]");
		print("C_NAME [" + c.gameObject.name + "]");

		audio_ping.Play();

		if (c.gameObject.tag == "Player" || 
			c.gameObject.name == "left_wall" ||
			c.gameObject.name == "right_wall") {

			float x = hitFactor(transform.position, c.transform.position, c.collider.bounds.size.x);

			//Calculate direction, make wight=1 via .normalized
			//                       (x, y)
			Vector2 dir = new Vector2(x, 1).normalized;
		
			//Set velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * (velocidade * 1.2f);
		}

		if (c.gameObject.tag == "Block") {

			count_blocks++;

			print ("COUNT [" + count_blocks +"]");

			if (count_blocks == 50) {
				SceneManager.LoadScene("final-scene");
			}

			GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidade;
		}

		if (c.gameObject.name == "ceiling") {
			GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidade;
		}
			
	}
		
	void OnTriggerEnter2D(Collider2D c) {

		if (c.gameObject.name == "floor") {

			audio_loose.Play ();

			ScoreScript.vida--;

			if (ScoreScript.vida == 0) {
				SceneManager.LoadScene ("intro-scene");
			}
		}
	}

	void OnTriggerExit2D(Collider2D c) {

		SpriteRenderer sp;
		sp = player.GetComponent<SpriteRenderer> ();

		if (ScoreScript.vida == 2) {
			sp.sprite = destroyed_1;
		} else {
			sp.sprite = destroyed_2;
		}

		transform.position = new Vector2(0.05f, -3.03f);

		player.transform.position = new Vector2(0.11f, -4.55f);

			
	}

}
