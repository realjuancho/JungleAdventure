using UnityEngine;
using System.Collections;

public class DetectionRay : MonoBehaviour {



	public Vector2 directionToDetectFrom = Vector2.up;

	public float distanceToDetect = 0.3f;

	public bool detected;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		RaycastHit2D hit = Physics2D.Raycast (transform.position, directionToDetectFrom, distanceToDetect);

		detected = hit;
		Color color; 
		if(detected) 
		 	color = Color.green;
		else 
			color = Color.red;
		Debug.DrawRay(transform.position, directionToDetectFrom, color);
	}

}
