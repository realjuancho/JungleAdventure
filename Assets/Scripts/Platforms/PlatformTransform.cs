using UnityEngine;
using System.Collections;

public class PlatformTransform : MonoBehaviour {



	void OnCollisionEnter2D(Collision2D col)
	{
		col.gameObject.transform.SetParent(gameObject.transform);

	}

	void OnCollisionExit2D(Collision2D col)
	{
		col.gameObject.transform.SetParent(null);
	}
}

