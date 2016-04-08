using UnityEngine;
using System.Collections;

public class PickupCheck : MonoBehaviour {


	AttackAbility attackAbility;

	
	// Use this for initialization
	void Start () {

		attackAbility = gameObject.transform.parent.GetComponentInChildren<AttackAbility>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		Pickup pickup = col.GetComponent<Pickup>();

		if(pickup)
		{
			//Debug.Log(pickup.pickupElement);
	
			switch(pickup.pickupElement)
			{
			case Pickup.PickupElement.Earth:
				attackAbility.AddAttackHealth(Attack.AttackElement.Earth, pickup.pickupElementValue);
				break;
			case Pickup.PickupElement.Ice:
				attackAbility.AddAttackHealth(Attack.AttackElement.Ice, pickup.pickupElementValue);
				break;
			case Pickup.PickupElement.Fire:
				attackAbility.AddAttackHealth(Attack.AttackElement.Fire, pickup.pickupElementValue);
				break;
			case Pickup.PickupElement.Lightning:
				attackAbility.AddAttackHealth(Attack.AttackElement.Lightning, pickup.pickupElementValue);
				break;

			case Pickup.PickupElement.Money:
				GameManager.AddMoney();
				break;
			}


		}
	}

}
