using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Objective))]
public class ObjectiveTargetTime : MonoBehaviour {

	public double _targetTime = 300;

	public Objective objective;

	// Use this for initialization
	void Awake () {

		objective = GetComponent<Objective>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool compareTargetTime(double obtainedTime)
	{
		if(_targetTime > obtainedTime)
		{
			objective.ObjectiveCompleted = true;
			return true;
		}

		return false;
	}

}
