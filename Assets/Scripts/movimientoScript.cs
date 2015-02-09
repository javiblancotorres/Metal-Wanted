using UnityEngine;
using System.Collections;

public class movimientoScript : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(2,3);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var forceX = 0f;
		var forceY = 0f;


		if(Input.GetKey ("right")) {
			
			//esto lo que hace es frenar cuando voy a izquierda y pulso derecha
			if (rigidbody2D.velocity.x < 0){
				rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
			}
			if (absVelX < maxVelocity.x)
				forceX = speed;
			//esto de abajo pone al script mirando a la derecha
			this.transform.localScale = new Vector3(1, 1, 1);
		}
		else if (Input.GetKey ("left"))
		{
			//esto lo que hace es frenar cuando voy a derecha y pulso izquierda
			if(rigidbody2D.velocity.x > 0){
				rigidbody2D.velocity = new Vector2(0,rigidbody2D.velocity.y);
			}
			
			if(absVelX < maxVelocity.x)
				forceX = -speed;
			
			//esto de abajo pone al script mirando a la izquierda.
			this.transform.localScale = new Vector3 (-1, 1, 1);
		}
		rigidbody2D.AddForce (new Vector2 (forceX, forceY));
	
	}
}
