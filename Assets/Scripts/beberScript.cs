using UnityEngine;
using System.Collections;

public class beberScript : MonoBehaviour {

	public GameObject Bebido;
	public float tiempo = 2f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time > tiempo) {
			var clone = Instantiate(Bebido, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

	}

}
