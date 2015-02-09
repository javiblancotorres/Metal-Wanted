using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {

	// Use this for initialization

	public string nombreNivel = "scene_02"; //Nombre de la escena que vamos a cargar

	public float tiempoEspera = 2f;

	bool cargando = false; // Controla si el player esta dentro del trigger

	void OnTriggerStay2D(Collider2D target){

				if (target.transform.tag == "Player") {
						//Application.LoadLevel (nombreNivel);
						if (!cargando)//Si no esta cargando empezamos la cuenta atras.
								StartCoroutine (cargaNivel ());
				}
		}


		//Si salimos del trigger cortamos la carga
	void OnTriggerExit2D(Collider2D target){
			cargando = false;
		}


	
	//Ejecutamos esto cuando entramos en el trigger
	IEnumerator cargaNivel (){
		cargando = true;
		yield return new WaitForSeconds (tiempoEspera); //Esperamos el tiempo
		if (cargando) //Si sigue en el trigger cargamos la escena
						Application.LoadLevel (nombreNivel);
		}



}