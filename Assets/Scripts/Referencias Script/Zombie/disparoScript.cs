using UnityEngine;
using System.Collections;

public class disparoScript : MonoBehaviour {

	public GameObject bala;
	public Transform puntoDisparo;


	public void Fire (){
	    
		//Si el jugador tiene bala distinta a  null (ninguna) generara un disparo desde el puntoDisparo y con rotacion estandar, y si el jugador no tiene bala, no pasara nada.
		if (bala != null) {
			var clone = Instantiate (bala, puntoDisparo.position,
			                         Quaternion.identity) as GameObject;
			clone.transform.localScale = transform.localScale;
		}
	}
}
