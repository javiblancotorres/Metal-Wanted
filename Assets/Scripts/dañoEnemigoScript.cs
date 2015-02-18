using UnityEngine;
using System.Collections;

public class dañoEnemigoScript : MonoBehaviour {
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


	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.transform.tag == "Player") 
						salud = salud - 50;

        if (target.transform.tag == "SuperPlayer")
						salud = salud - 100;
		if (salud < 1) {
						vida = false;
				}else{
			vida = true;

		}

		if (vida = false) {
			Destroy(gameObject);		
		}

	}
}
