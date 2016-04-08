﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Player player = col.gameObject.GetComponent<Player>();
		if(player)
		{

			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

	}
}
