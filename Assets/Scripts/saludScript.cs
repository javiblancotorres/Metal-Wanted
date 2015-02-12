using UnityEngine;
using System.Collections;

public class saludScript : MonoBehaviour {

	public int salud = 100;

	private int maxsalud;

	// Use this for initialization
	void Start () {
		maxsalud = salud;

	}
	
	// Update is called once per frame
	void Update () {
		if (salud > maxsalud) {
			salud = maxsalud ;
		}
	}
	void OnCollisionEnter2D (Collision2D target){

		if (target.transform.tag == "salud") {
			salud = salud + 5;	


		} 
	}

}
