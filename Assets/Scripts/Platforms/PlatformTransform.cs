using UnityEngine;
using System.Collections;

public class PlatformTransform : MonoBehaviour {


	void Start()
	{

	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.GetComponent<Player>())
		{
			Debug.Log("Player ON");
			col.gameObject.transform.SetParent(gameObject.transform);
		}	
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.GetComponent<Player>())
		{
			Debug.Log("Player ON");
			col.gameObject.transform.SetParent(gameObject.transform);
		}	
	}


	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.GetComponent<Player>())
		{
			Debug.Log("Player OFF");
			col.gameObject.transform.SetParent(null);
		}
	}
}

