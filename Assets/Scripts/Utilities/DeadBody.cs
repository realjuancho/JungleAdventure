using UnityEngine;
using System.Collections;

public class DeadBody : MonoBehaviour {


	public float timeToDisappear = 3.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	float timeSinceAlive = 0.0f;
	void Update () {
		timeSinceAlive +=Time.deltaTime;

		if(timeSinceAlive >= timeToDisappear)
		{
			Destroy(gameObject);
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{

		DeadBody otherDeadBody = col.collider.gameObject.GetComponent<DeadBody>();

		if(otherDeadBody)
		{
			otherDeadBody.GetComponent<BoxCollider2D>().enabled = false;
		}

	}
}
