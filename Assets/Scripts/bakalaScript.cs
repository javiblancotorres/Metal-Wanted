using UnityEngine;
using System.Collections;

public class bakalaScript : MonoBehaviour {

	public GameObject navaja;

	public float speed = 0.4f;
	public Transform checkMuros, checkSuelos, puntoDisparo;
	private bool veomuro = false;
	private bool veosuelo = true;
	private bool veoplayer = false;
	private Vector2  direction;

	public int salud = 100;
	public bool vida;
	private int maxsalud;
	public bool muerte;

	public bool estacerca = false;
	public bool ataque;

	public static bool Ataque; 

	private float vAbs;
	private float velocidad;
	public float tiempo_espera = 0;

	private Animator animacion;


	// Use this for initialization
	void Start () {
		velocidad = speed;

		maxsalud = salud;
		vida = true; 



		animacion = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		gira_si_no_avanza();
		gira_si_veo_muro();
		gira_si_no_hay_suelo();
		busca_player();
		rigidbody2D.velocity = new Vector2(this.transform.localScale.x * velocidad, rigidbody2D.velocity.y);

		if (ataque == true) {
			var clone = Instantiate (navaja, puntoDisparo.position, Quaternion.identity) as GameObject;

		}
			
	}


	void mediavuelta(){
				this.transform.localScale = new Vector3 (this.transform.localScale.x , this.transform.localScale.y, this.transform.localScale.z);
		}

	void gira_si_no_avanza(){
		vAbs =  Mathf.Abs (rigidbody2D.velocity.x);
		if(vAbs < 0.1f && !veoplayer){
			if(tiempo_espera == 0){
				tiempo_espera = Time.time + 3;
			}else if(tiempo_espera < Time.time){
				tiempo_espera = 0;
				mediavuelta();
			}
		}
}

	void gira_si_veo_muro(){
		veomuro = Physics2D.Linecast (transform.position, checkMuros.position, 1 << LayerMask.NameToLayer ("suelo"));
		Debug.DrawLine (transform.position, checkMuros.position,Color.green);
		if (veomuro)
			mediavuelta();
	}

	void gira_si_no_hay_suelo(){
		veosuelo = Physics2D.Linecast (transform.position, checkSuelos.position, 1 << LayerMask.NameToLayer ("suelo"));
		Debug.DrawLine (transform.position, checkSuelos.position,Color.red);
		if (!veosuelo)
			mediavuelta();
	}
 
	void busca_player(){
		direction  = checkMuros.position-transform.position;
		var ray = new Ray2D(transform.position,direction.normalized);
		//Debug.DrawRay(ray.origin, ray.direction*2);
		var hit = Physics2D.Raycast(ray.origin, ray.direction,2, 1 << LayerMask.NameToLayer ("Player"));
		/*if (hit.collider != null && hit.transform.tag == "Player") {

						animacion.SetBool ("ataque", true);
				} else {
						animacion.SetBool ("ataque", false); 

				}*/
		}





	void OnCollisionEnter2D(Collision2D Player){
		if (movimientoScript.bofeton == true) {
						salud = salud - 50;
				}

		if (salud <= 0) {
			vida = false;

			
		}
		
		if (vida == false) {
			Destroy(gameObject);
		
		}
		
	}
	void OnTriggerEnter2D(Collider2D Player){
		animacion.SetBool ("ataque", true) ;
		ataque = true;

	}
	
	void OnTriggerExit2D(Collider2D Player){
		ataque = false;
		animacion.SetBool ("ataque", false);
	}

}



