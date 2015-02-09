using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {
	
	public float jumpSpeed = 5f;
	public float superJump = 2;
	public bool standing;
	public GameObject groundCheck;
	
	// Update is called once per frame
	void Update () {
		var absVelY = Mathf.Abs(rigidbody2D.velocity.y);
		// Busco el valor absoluto en el eje y para saber si estoy en movimiento vertical o no. En caso de estar en movimiento vertical no puedo saltar
		//esto puede ser una desventaja si por ejemplo me subo en un elevador (me impediria saltar)
		if(absVelY <= .05f){
			standing = true;
		}else{
			standing = false;
		}
		
		if( (Input.GetKeyDown("up") || Input.GetKeyDown("space")) && standing){
			rigidbody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
		}
	}
	
	//Si salimos del trigger cortamos la carga
	void OnTriggerExit2D(Collider2D target){
		if (target.transform.tag == "SuperJump") {
			jumpSpeed = jumpSpeed / superJump;
		}
	}
	
	void OnTriggerEnter2D(Collider2D target){
		if (target.transform.tag == "SuperJump") {
			jumpSpeed = jumpSpeed * superJump;
		}
	}
}
