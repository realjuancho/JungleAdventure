using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {


	GameManager gameManager;

	void Start()
	{
		gameManager = GameObject.FindObjectOfType<GameManager>();
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Player player = col.GetComponent<Player>();

		if(player)
			gameManager.LastCheckPoint(gameObject.GetComponent<CheckPoint>());

	}


}
