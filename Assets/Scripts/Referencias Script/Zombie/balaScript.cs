using UnityEngine;
using System.Collections;

public class balaScript : MonoBehaviour {


	public Vector2 velocity = new Vector2 (5, 0);
	public GameObject particulas;


	void Start () {
		//rigidbody2D.velocity = velocity * transform.localScale.x;
		rigidbody2D.AddForce (velocity * transform.localScale.x, ForceMode2D.Impulse);
		//En vez de velocity, al hacerlo de la manera AddForce y el ForceMode2D.Impulse la bala recibira un impulso
	}


	void OnCollisionEnter2D(Collision2D target){
		//Destroy (gameObject);
		explotaBala ();
	
	
	}

	void explotaBala(){
		var clone = Instantiate (particulas, transform.position, Quaternion.identity)
			as GameObject;
		Destroy (clone, 1);
		//Destroy (gameObject);
	
	}


}
