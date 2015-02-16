using UnityEngine;
using System.Collections;

public class saludScript : MonoBehaviour {

	public int salud = 100;
	public bool vida;

	private int maxsalud;

	// Use this for initialization
	void Start () {
		maxsalud = salud;
		vida = true; 

	}
	
	// Update is called once per frame
	void Update () {
		if (salud > maxsalud) {
			salud = maxsalud ;
		}
		if (salud > 1) {
			vida = true;	
		}
		if (salud < 1) {
			vida = false;		
		}
		if (vida = false) {
			Destroy(gameObject);	
		
		}

	}
	void OnCollisionEnter2D (Collision2D target){

		if (target.transform.tag == "salud") {
			salud = salud + 5;	


		}

		if (target.transform.tag == "bacala") {
						salud = salud - 30;
				}
	}

}
