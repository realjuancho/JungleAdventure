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

	SoundEffects soundEffects;
	AudioSource audioSource;
	float gravityScale;

	void Start()
	{
		myRigidBody2D = GetComponent<Rigidbody2D>();
		gravityScale = myRigidBody2D.gravityScale;

		characterHealth = GetComponentInChildren<HealthPoints>();
		character = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();


		soundEffects = GetComponent<SoundEffects>();
		audioSource = gameObject.AddComponent<AudioSource>();

	}

	void Update()
	{
		HandleDeath();
		HandleDamage();

		JumpSounds();
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


		myRigidBody2D.isKinematic = false;
	}

	public void CanControl(bool canControl)
	{
		character.canMove = canControl;
		character.StopAnimations();



	}

	public void Stop()
	{

		myRigidBody2D.isKinematic = true;

		myRigidBody2D.velocity = Vector2.zero;
		myRigidBody2D.angularVelocity = 0;

		character.StopAnimations();

	}


	public void JumpSounds()
	{

		if(!audioSource.isPlaying)
			if(character.hasJumped)
			{
				
				float f = Random.Range(0.0f,1.0f);

				if(f >= 0.0f && f < 0.20f)
					audioSource.clip = soundEffects.audioClips[0];

				if(f >= 0.20f && f <= 0.40f)
					audioSource.clip = soundEffects.audioClips[1];


				audioSource.transform.position = transform.position;
				audioSource.Play();

				
			}
	}


	bool withinLadder;

	void OnTriggerStay2D(Collider2D col)
	{
		if(col.GetComponent<Ladder>())
		{
			withinLadder = true;
			ManageClimbing(withinLadder);

		}
	} 

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.GetComponent<Ladder>())
		{
			withinLadder = true;
			ManageClimbing(withinLadder);
		
		}
	} 

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.GetComponent<Ladder>())
		{
			withinLadder = false;
			ManageClimbing(false);

		}
	} 


	bool isClimbing = false;
	bool attemptClimb = false;
	void ManageClimbing(bool withinClimbArea)
	{
		bool touchUp = (TouchPadInput.MovementAxis_Vertical > 0f);
			bool touchDown = (TouchPadInput.MovementAxis_Vertical < 0f);
			bool KeyUp = Input.GetKey(KeyCode.UpArrow);
			bool KeyDown = Input.GetKey(KeyCode.DownArrow);
			bool KeyW = Input.GetKey(KeyCode.W);
			bool KeyS = Input.GetKey(KeyCode.S);
			float DPadUpDown = Input.GetAxis(Hash.Axis.DPad_UpDown);
			float LAnalogUpDown = Input.GetAxis(Hash.Axis.LStick_UpDown);

		if(withinClimbArea)
		{
			
			if(touchUp ||
				touchDown ||
					KeyUp ||
					KeyDown ||
					KeyW ||
					KeyS ||
					DPadUpDown != 0 ||
					LAnalogUpDown != 0
					)
				{  
					isClimbing = true;
					attemptClimb = true;
					myRigidBody2D.gravityScale = 0.0f;
				}
			else
			{
				isClimbing = false;
			}

			if(touchUp || KeyUp || KeyW || DPadUpDown > 0 || LAnalogUpDown < 0)
				{
					character.MoveUD(Vector2.up);
				}
			else if(touchDown || KeyDown || KeyS || DPadUpDown < 0 || LAnalogUpDown > 0)
				{
					character.MoveUD(Vector2.down);
				}
			else
			{
				if(attemptClimb)
					character.MoveUD(Vector2.zero);
			}


		}
		else
		{
			myRigidBody2D.gravityScale = gravityScale;
			isClimbing = false;
			attemptClimb = false;
			character.MoveUD(true);
		}


	}
	
}
