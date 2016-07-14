using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {



	Rigidbody2D myRigidBody2D;

	// Use this for initialization
	void Start () {

		myRigidBody2D = GetComponent<Rigidbody2D>();

		myRigidBody2D.AddForce(Vector2.up * 2.0f, ForceMode2D.Impulse);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
