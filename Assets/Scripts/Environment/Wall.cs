using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {


	public enum WallType { Ice, Lava, Stone, Electricity, EnemyBlock }
	public WallType myWallType;

	public float myWallHealth = 30.0f; 
	public int enemyCount;

	void OnTriggerEnter2D(Collider2D col)
	{
		Attack att = col.gameObject.GetComponent<Attack>();

		if(att)
		{
		    Attack.AttackElement element = att.attackElement;

		    bool causesDamage=false;
		    switch(myWallType)
		    {
		    	case WallType.Ice:
		    		if(element == Attack.AttackElement.Fire)
		    			causesDamage = true;
		    		break;
					case WallType.Lava:
			    		if(element == Attack.AttackElement.Ice)
			    			causesDamage = true;
			    		break;
					case WallType.Electricity:
			    		if(element == Attack.AttackElement.Earth)
			    			causesDamage = true;
			    		break;
					case WallType.Stone:
		    			if(element == Attack.AttackElement.Lightning)
		    				causesDamage = true;
		    		break;
		    }
		    if(causesDamage)
		    	myWallHealth -= att.attackDamage;
	    }
	}

	void Update()
	{
		if(myWallHealth <= 0.0f)
			Destroy(gameObject);

	}
}
