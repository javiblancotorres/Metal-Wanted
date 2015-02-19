using UnityEngine;
using System.Collections;

public class cervezaScript : MonoBehaviour {

	public bool super;
	public bool bebiendo;
	public float tiempobebiendo = 2f;
	public float tiemposuper = 5f;
	public float supertime = 0;

	private Animator beber; 

	// Use this for initialization
	void Start () {

		beber = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	if ( (Time.time > supertime) && bebiendo) {
			beber.SetBool ("bebiendo", false);
			beber.SetBool ("super",true);
			bebiendo = false;
			super = true;
			supertime = Time.time + tiemposuper;
		}

		if ( (Time.time > supertime) &&  super) {
			beber.SetBool ("super",false);
			super = false;

		}


	}
	
	/* void OnCollisionEnter2D (Collision2D target){

		if (target.transform.tag == "cerveza") {
			bebiendo = true;
			beber.SetBool ("bebiendo", true);
			beber.SetBool ("super",false);
			supertime = Time.time + tiempobebiendo;

			}
			    		
		}*/

	}


		