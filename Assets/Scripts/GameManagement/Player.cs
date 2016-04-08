using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Player : MonoBehaviour {


	Rigidbody2D myRigidBody2D;

	public float damageValue = 10.0f;
	public float timeToRecover = 0.5f;
	public float damageFactor = 5f;
	public float damageFactorUP = 5f;
	public bool isDead;


	public GameObject deadBodyPrefab;


	[SerializeField] bool receiveDamage;
	[SerializeField] float timeSinceHit = 0.0f;

 	HealthPoints characterHealth;
	UnityStandardAssets._2D.PlatformerCharacter2D character;



	void Start()
	{
		myRigidBody2D = GetComponent<Rigidbody2D>();

		characterHealth = GetComponentInChildren<HealthPoints>();
		character = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
	}

	void Update()
	{
		HandleDeath();
		HandleDamage();
	}

	void HandleDamage()
	{

		if(receiveDamage)
		{
			timeSinceHit += Time.deltaTime;	
			Vector2 damageDirection;

			if(PlatformerCharacter2D.IsPlayerFacingRight())
				damageDirection = new Vector2(-damageFactor,damageFactorUP);
			else
				damageDirection = new Vector2(damageFactor,damageFactorUP);

			myRigidBody2D.AddForce(damageDirection * damageValue, ForceMode2D.Impulse);
			PlatformerCharacter2D.CanControl(false);
		}


		if(timeSinceHit >= timeToRecover)
		{
			timeSinceHit = 0.0f;
			PlatformerCharacter2D.CanControl(true);
			receiveDamage = false;	
		}
	}

	bool triggeredDeath;
	void HandleDeath()
	{

		if(characterHealth.healthValue <= 0 && !triggeredDeath)
		{
			character.Die();


			triggeredDeath = true;

			GameManager.AddExplorerCount();
		}




		if(character.IsDeathAnimationFinished() && triggeredDeath)
		{
			isDead = true;
			GameObject deadBody =  (GameObject)Instantiate(deadBodyPrefab, transform.position, Quaternion.identity);
			deadBody.GetComponent<SpriteRenderer>().flipX = !character.isFacingRight;
		}

	}

	public void ReSpawn(Vector3 RespawnPosition)
	{
		characterHealth.AddHealth(characterHealth.maxHealthValue);
			transform.position = RespawnPosition;
			transform.SetParent(null);

			isDead=false;
			triggeredDeath=false;

			character.ReSpawn();
	}
	
}
