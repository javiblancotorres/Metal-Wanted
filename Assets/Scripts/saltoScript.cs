using UnityEngine;
using System.Collections;

public class saltoScript : MonoBehaviour {

	public float jumpSpeed = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown("up")){
			rigidbody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
		}
	}
	}

