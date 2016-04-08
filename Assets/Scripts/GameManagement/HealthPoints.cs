using UnityEngine;
using System.Collections;

public class HealthPoints : MonoBehaviour {


	public bool isDead = false;

	public bool isInvincible;
	public float timeSinceInvincible;
	public float invincibilityTime = 3.0f;

	public float maxHealthValue = 30.0f;
	public float healthValue = 30.0f;



	void Update()
	{
		CheckInvincibility();
		CheckIsDead();
	}

	public void AddHealth(float healthToAdd)
	{
		if(maxHealthValue > healthValue + healthToAdd)
		{
			healthValue = maxHealthValue;
		}
		else healthValue += healthToAdd;
	}

	public void GetDamage(float damageTaken)
	{
		healthValue -= damageTaken;

	}

	public void CheckIsDead()
	{
		if(healthValue <= 0) isDead = true;
		else isDead = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		CheckForHazard(col.gameObject);
	}
	void OnTriggerStay2D(Collider2D col)
	{	
		CheckForHazard(col.gameObject);
	}


	void CheckForHazard(GameObject col)
	{
		Hazard hazard = col.GetComponent<Hazard>();
		if(hazard)
		{
			if(!hazard._1HitKill)
			{
				if(!isInvincible)
				{
					GetDamage(hazard.damage);
					isInvincible = true;
					timeSinceInvincible = 0.0f;
				}
			}
			else
			{
				GetDamage(maxHealthValue);
			}
		}
	}

	void CheckInvincibility()
	{
		if(isInvincible)
			timeSinceInvincible += Time.deltaTime;
		if(timeSinceInvincible >= invincibilityTime)
		{
			isInvincible = false;
		}

	}
	
}
