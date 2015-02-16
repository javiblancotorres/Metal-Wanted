using UnityEngine;
using System.Collections;

public class cervezaScript : MonoBehaviour {

	public GameObject Beber1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	void OnCollisionEnter2D (Collision2D target){

		if (target.transform.tag == "salud") {
			var clone = Instantiate(Beber1, transform.position, Quaternion.identity);
			Destroy (gameObject);
			}
	}
}
