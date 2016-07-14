using UnityEngine;
using System.Collections;

public class ObjectiveBounds : MonoBehaviour {

	public enum BoundType { Rigid, Triggers };
	public BoundType myBoundType;
	public bool boundsActive = false;

	PolygonCollider2D myCollider;
	float maxTimeToLeaveBounds;
	float timeSinceLeftBounds;

	// Use this for initialization
	void Start () {

		myCollider = GetComponent<PolygonCollider2D>();
		switch (myBoundType)
		{
			case BoundType.Rigid:
				myCollider.isTrigger=false;
			break;
			case BoundType.Triggers:
				myCollider.isTrigger = true;
			break;

		}
		
	}
	
	// Update is called once per frame
	void Update () {


		myCollider.enabled = boundsActive;	
	}


	void OnTriggerEnter2D()
	{
		

	}
}
