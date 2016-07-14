using UnityEngine;
using System.Collections;

public class ObjectiveTrigger : MonoBehaviour {


	public bool objectiveTriggered;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D col)
	{

		Player p =  col.gameObject.GetComponent<Player>();

		if(p)
		{
			objectiveTriggered = true;
		}
			

	}
}
