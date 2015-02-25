﻿using UnityEngine;
using System.Collections;

public class navajaScript : MonoBehaviour {

	public Vector2 velocity = new Vector2 (5, 0);
	public GameObject particulas;

	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce (velocity * transform.localScale.x, ForceMode2D.Impulse);
	}
	
	void OnCollisionEnter2D(Collision2D target){
		if ((target.transform.tag == "Player") || target.transform.tag == "suelo") {
						Destroy (gameObject);
				}

	}



}

