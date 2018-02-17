using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public int vida;
	public float velocidade;

	void Mover() {

		//Mover
		//resposta instantanea GetAxisRaw
		//float move_x = Input.GetAxisRaw ("Horizontal") * velocidade * Time.deltaTime;
		//float move_y = Input.GetAxisRaw ("Vertical") * velocidade * Time.deltaTime;
		//transform.Translate (move_x, move_y, 0.0f);
		//transform.Translate (move_x, 0.0f, 0.0f);

		float move_x = Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody2D>().velocity = Vector2.right * move_x * velocidade;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//print(vida);
		Mover();
	}

	void OnCollisionEnter2D(Collision2D c){

		if (c.gameObject.name == "left_wall") {
			//transform.position = new Vector2 (transform.position.x + 0.2f, transform.position.y); 
			transform.position = new Vector2 (transform.position.x + 0.001f, transform.position.y);
		}

		if (c.gameObject.name == "right_wall") {
			transform.position = new Vector2 (transform.position.x + 0.2f, transform.position.y); 
		}
	}

}
