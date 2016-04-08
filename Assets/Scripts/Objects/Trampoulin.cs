using UnityEngine;
using System.Collections;

public class Trampoulin : MonoBehaviour {

	// Use this for initialization

	float trampoulineForce = 10.0f;



	void OnCollisionEnter2D(Collision2D col)
	{

		

		Rigidbody2D colRigidBody2D = col.gameObject.GetComponent<Rigidbody2D>();
		if(colRigidBody2D)
		{
			colRigidBody2D.AddForce(new Vector2(0,trampoulineForce), ForceMode2D.Impulse);
		}

	}

}
