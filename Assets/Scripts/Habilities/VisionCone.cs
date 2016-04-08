using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisionCone : MonoBehaviour {


	public List<GameObject> GameObjectWithinVision;


	void OnTriggerEnter2D(Collider2D col)
	{

		if(!GameObjectWithinVision.Contains(col.gameObject))
		{
			GameObjectWithinVision.Add(col.gameObject);
		}

	}


	void OnTriggerExit2D(Collider2D col)
	{
		if(GameObjectWithinVision.Contains(col.gameObject))
		{
			GameObjectWithinVision.Remove(col.gameObject);
		}

	}
}
