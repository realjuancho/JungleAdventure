using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class SlipperySlope : MonoBehaviour {


	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionStay2D(Collision2D col)
	{
		if(col.gameObject.GetComponent<Player>())
		{
			PlatformerCharacter2D pcd = col.gameObject.GetComponent<PlatformerCharacter2D>();
			pcd.canMove = false;


		}

	}

	void OnCollisionExit2D(Collision2D col)
	{
		if(col.gameObject.GetComponent<Player>())
		{
			PlatformerCharacter2D pcd = col.gameObject.GetComponent<PlatformerCharacter2D>();
			pcd.canMove = true;


		}

	}
}
