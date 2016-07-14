using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Objective))]
public class ObjectiveTargetLives: MonoBehaviour {

	public int _targetLives = 3;

	public Objective objective;

	// Use this for initialization
	void Awake () {

		objective = GetComponent<Objective>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool compareTargetLives(double LivesUsed)
	{
		if(LivesUsed < _targetLives)
		{
			objective.ObjectiveCompleted = true;
			return true;
		}

		return false;
	}

}