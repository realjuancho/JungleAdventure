using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveChecker : MonoBehaviour {


	public enum ObjectiveCheckerType {Required, Optional} ;

	public bool isActive = false;
	public ObjectiveTrigger myObjectiveTrigger;

	public string ObjectiveMessage;
	public ObjectiveBounds myObjectiveBounds;
	public ObjectiveCheckerType myObjectiveCheckerType;
	public CameraObjectiveRestrictor myCameraObjectiveRestrictor;
	public CheckPoint checkPointToSpawn;
	public bool ObjectiveComplete;

	public List<Objective> objectivesToCheck;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {


		
		ObjectiveComplete = CheckForObjectives();
		if(ObjectiveComplete) 
			{
				isActive = false;
				GameManager.RemoveObjective();
			}
		else CheckForTrigger();

		if(isActive)
			GameManager.SetObjective(ObjectiveMessage);
		


		CheckForBounds();
	}


	bool CheckForObjectives()
	{

		foreach(Objective o in objectivesToCheck)
		{
			if(!o.ObjectiveCompleted)
				return false;
			
		}

		return true;
	}

	void CheckForTrigger()
	{
		if(myObjectiveTrigger) {

				if(myObjectiveTrigger.objectiveTriggered) isActive = true;
		}
		else isActive = true;

	}

	void CheckForBounds()
	{
		if(myObjectiveBounds) myObjectiveBounds.boundsActive = isActive;
	}
}
