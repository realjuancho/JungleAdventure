using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Objective : MonoBehaviour {

	public enum ObjectiveType { Collect , Kill, Open , Boss, Time, Lives  }

	public string ObjectiveGroup;

	public ObjectiveType _objectiveType;

	public bool ObjectiveCompleted = false;


	// Use this for initialization
	void Start () {

		
	}
	
	public void CheckTargets(int coins, int lives, double time)
	{

		ObjectiveTargetCoins otc = GetComponent<ObjectiveTargetCoins>();
		if(otc) otc.compareTargetCoins(coins);

		ObjectiveTargetTime ott = GetComponent<ObjectiveTargetTime>();
		if(ott) ott.compareTargetTime(time);


		ObjectiveTargetLives otl = GetComponent<ObjectiveTargetLives>();
		if(otl) otl.compareTargetLives(lives);


	}
}
