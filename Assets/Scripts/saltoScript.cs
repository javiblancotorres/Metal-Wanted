﻿using UnityEngine;
using System.Collections;

public class saltoScript : MonoBehaviour {

	public float jumpSpeed = 5f;
	public bool tocasuelo = false;
	public bool saltar;

	private Animator salto;

	// Use this for initialization
	void Start () {

		salto = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

	

	

		if( (Input.GetKeyDown("up") || Input.GetKeyDown("space")) && tocasuelo) {
			rigidbody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);

		}
	}
}
