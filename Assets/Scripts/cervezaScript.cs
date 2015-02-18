using UnityEngine;
using System.Collections;

public class cervezaScript : MonoBehaviour {

	public bool super;
	public bool bebiendo;
	public float tiempo = 2f;

	private Animator beber; 

	// Use this for initialization
	void Start () {

		beber = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnCollisionEnter2D (Collision2D target){

		if (target.transform.tag == "cerveza") {
						beber.SetBool ("bebiendo", true);
			beber.SetBool ("super",false);

			}
			    		
		}

	}


		