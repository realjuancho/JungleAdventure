using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {


	public float timeelapsed = 0.0f;

	bool heroArrived = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!heroArrived)
		timeelapsed += Time.deltaTime;
	}

	void OnTriggerEnter2D()
	{
		heroArrived=true;
		Debug.Log("time to Arrive"+timeelapsed);
	}

}
