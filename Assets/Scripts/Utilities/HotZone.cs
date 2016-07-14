using UnityEngine;
using System.Collections;

public class HotZone : MonoBehaviour {

	public bool playerInHotZone;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.GetComponent<Player>())
		{
			playerInHotZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.GetComponent<Player>())
		{
			playerInHotZone = false;
		}
	}


}
