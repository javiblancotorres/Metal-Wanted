using UnityEngine;
using System.Collections;

public class saltoScript : MonoBehaviour {

	public float jumpSpeed = 5f;
	public bool tocasuelo = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	

	

		if( (Input.GetKeyDown("up") || Input.GetKeyDown("space")) && tocasuelo) {
			rigidbody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);

		}
	}

	void OnCollisionEnter2D(Collision2D target){

		if (target.transform.tag == "suelo"){
			tocasuelo = true;
		}
	}

	void OnCollisionExit2D(Collision2D target){

		if (target.transform.tag == "suelo"){
			tocasuelo = false;
		}
	}
}
