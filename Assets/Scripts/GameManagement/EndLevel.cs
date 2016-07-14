using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EndLevel : MonoBehaviour {

	public int levelToUnlock;

	public int unlockedDiamonds;

	public ObjectiveChecker endLevelObjectiveChecker;

	void Start()
	{
		endLevelObjectiveChecker = gameObject.GetComponentInChildren<ObjectiveChecker>();
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		Player player = col.gameObject.GetComponent<Player>();
		if(player)
		{
			GameManager.ReachEndLevel(levelToUnlock, unlockedDiamonds);

			CheckLevelObjectives();
		}
	}

	void CheckLevelObjectives()
	{
		

		List<Objective> objectiveArray = endLevelObjectiveChecker.objectivesToCheck;

		unlockedDiamonds = 0;
		foreach(Objective objective in objectiveArray)
		{
			objective.CheckTargets(GameManager.getMoney(), GameManager.getExplorersUsed(), GameManager.getTimeUsed());
			
			if(objective.ObjectiveCompleted)
				unlockedDiamonds++;
		}
	}
}
