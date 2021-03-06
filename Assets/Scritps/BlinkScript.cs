﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class BlinkScript : MonoBehaviour {

	public float intervalo;
	public AudioSource audio;

	// Use this for initialization
	IEnumerator Start () {

		//Obtem o componente do objeto
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (intervalo);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (intervalo);

		//Faz a chamada novamente do metodo deixando em looing
		StartCoroutine(Start());
	}

	// Use this for initialization
	//void Start () {	}
	
	// Update is called once per frame
	void Update () {
		
		//Pressionar enter
		if(Input.GetKeyDown(KeyCode.Return)) {
			audio.Play();
			SceneManager.LoadScene("game-scene");
		}
	}
}
