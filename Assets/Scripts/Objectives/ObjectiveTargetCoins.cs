using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Objective))]
public class ObjectiveTargetCoins : MonoBehaviour {

	public int _targetCoins = 10;

	public Objective objective;

	// Use this for initialization
	void Awake () {

		objective = GetComponent<Objective>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool compareTargetCoins(int obtainedCoins)
	{
		if(obtainedCoins > _targetCoins)
		{
			objective.ObjectiveCompleted = true;
			return true;
		}

		return false;
	}

}
