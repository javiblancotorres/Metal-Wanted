using UnityEngine;
using System.Collections;

public class bofetonScript : MonoBehaviour {

	public bool bofeton;

	private Animator animacion; 



	// Use this for initialization
	void Start () {
		animacion = GetComponent<Animator> ();

		bofeton = false; 
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey ("z")) {
			animacion.SetBool ("bofeton", true);		
		}else{
			animacion.SetBool ("bofeton", false);

	}
}

}