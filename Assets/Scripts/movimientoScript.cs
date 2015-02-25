using UnityEngine;
using System.Collections;

public class movimientoScript : MonoBehaviour {

	public float speed = 10f;
	public float jumpSpeed = 5f;



	public Vector2 maxVelocity = new Vector2(2,3);
	public bool tocasuelo = false;
	public bool saltar;

	public static bool bofeton;

	public int numChachorritos = 0;
	private int maxCachorritos = 5;

	public bool lanzarcachorritos;
	 
	public bool super;
	public bool bebiendo;
	public float tiempobebiendo = 2f;
	public float tiemposuper = 5f;
	public float supertime = 0;

	public int salud = 100;
	public bool vida;
	private int maxsalud;

	//private Animator beber; 
	float derecha;
	float izquierda;

	private Animator animacion;

	
	// Use this for initialization
	void Start () {
		derecha = 1;
		izquierda = -1;

		//Salud
		maxsalud = salud;
		vida = true; 

		bofeton = false;



		animacion = GetComponent<Animator> ();



	}
	
	// Update is called once per frame
	void Update () {

				//Para el movimiento
				var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
				var forceX = 0f;
				var forceY = 0f;


				if (Input.GetKey ("right"))  {
			
						//esto lo que hace es frenar cuando voy a izquierda y pulso derecha
						if (rigidbody2D.velocity.x < 0) {
								rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
						}
						if (absVelX < maxVelocity.x)
								forceX = speed;
						//esto de abajo pone al script mirando a la derecha
						this.transform.localScale = new Vector3 (derecha, transform.localScale.y, transform.localScale.z);
				} 
				if (Input.GetKey ("left")) {
						//esto lo que hace es frenar cuando voy a derecha y pulso izquierda
						if (rigidbody2D.velocity.x > 0) {
								rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
						}
			
						if (absVelX < maxVelocity.x)
								forceX = -speed;


						//esto de abajo pone al script mirando a la izquierda.
						this.transform.localScale = new Vector3 (izquierda, transform.localScale.y, transform.localScale.z);

				}
				rigidbody2D.AddForce (new Vector2 (forceX, forceY));
		
				if (absVelX > 0) {

						animacion.SetFloat ("Andar", absVelX);

				}
				//Para el salto

				if ((Input.GetKeyDown ("up") || Input.GetKeyDown ("space")) && tocasuelo) {
						rigidbody2D.AddForce (new Vector2 (0, jumpSpeed), ForceMode2D.Impulse);
				}

				//Para pegar bofeton

				if (Input.GetKey ("z")) {
						animacion.SetBool ("bofeton", true); 
						bofeton = true;
				} 
			//Para no bofeton
			if (bofeton == false) {
				animacion.SetBool ("bofeton", false);
					}
	
		//Para el SuperMetalero
		if ( (Time.time > supertime) && bebiendo) {
			animacion.SetBool ("bebiendo", false);
			animacion.SetBool ("super",true);
			bebiendo = false;
			super = true;
			supertime = Time.time + tiemposuper;
		}
		
		if ((Time.time > supertime) && super) {
						animacion.SetBool ("super", false);
						super = false;

				}

		//Para lanzar cachorritos
		if (Input.GetKey ("x")) {
				
		}

		}

		void OnCollisionEnter2D(Collision2D target){
		//Para saltar	
			if (target.transform.tag == "suelo"){
				tocasuelo = true;
				animacion.SetBool ("saltar", false);
			}
		
		//Para SuperMetalero.
			if (target.transform.tag == "cerveza") {
				bebiendo = true;
				animacion.SetBool ("bebiendo", true);
				animacion.SetBool ("super",false);
				supertime = Time.time + tiempobebiendo;
				
			}
			
		//Para salud.

		if (target.transform.tag == "salud") {
			salud = salud + 20;	
			}
		
		if (target.transform.tag == "bacala" && !bofeton){
			salud = salud - 30;
		}

		//Para cachorritos.

		if (target.transform.tag == "cachorrito") {
			numChachorritos = numChachorritos + 1	;
		}
	}



	void OnCollisionExit2D(Collision2D target){
		//Para salto
		if (target.transform.tag == "suelo"){
			tocasuelo = false;
			animacion.SetBool ("saltar", true);
		}


	} 

	public void finbofeton(){
		bofeton = false;
	}


}
