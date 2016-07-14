using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public enum EnemyType { Dimetrodon, PteroDactyl };

	public float Health = 100.0f;
	public EnemyType myEnemyType;

	VisionCone visionCone;
	Hazard hazard;

	Player myPlayer;
	PolygonCollider2D enemyBodyCollider;
	SpriteRenderer sr;

    [SerializeField] bool turn;
  	[SerializeField] bool attack;


	private Animator animator;

	void Start()
	{
		
		animator = GetComponent<Animator>();	
		visionCone = GetComponentInChildren<VisionCone>();
		myPlayer = GameObject.FindObjectOfType<Player>();
		enemyBodyCollider =  gameObject.GetComponent<PolygonCollider2D>();

		hazard = transform.FindChild("AttackRange").gameObject.GetComponent<Hazard>();
		hazard.enabled = false;

		sr = transform.FindChild("DimetrodonBody").gameObject.GetComponent<SpriteRenderer>();
		originalColor = sr.color;
	}

	public void inflictDamage(float Damage, Shoot.ShootElement shootElement)
	{
		Health -= Damage;
	
		switch(shootElement)
		{
			case Shoot.ShootElement.Simple:
				targetColor = Color.black;
			break;

			case Shoot.ShootElement.Fire:
				targetColor = Color.red;
			break;

			case Shoot.ShootElement.Ice:
				targetColor = Color.blue;
			break;

			case Shoot.ShootElement.Earth:
				targetColor = Color.green;
			break;

			case Shoot.ShootElement.Lightning:
				targetColor = Color.yellow;
			break;

		}


		sr.color = targetColor;

		damaged	= true;

	}


	Color originalColor;
	Color targetColor = new Color(1,1,1,1);

	bool damaged;
	float timeSinceDamage = 0.0f;

	void CheckForDamage()
	{

		if(damaged)
		{

			timeSinceDamage += Time.deltaTime;

			if(timeSinceDamage < 0.2f)
			{
				sr.color = targetColor;

			}
			else
			{
				sr.color = originalColor;
				damaged = false;
			}
		}


		
	}



	public void inflictDamage(float Damage, Attack.AttackElement attackElement)
	{
		Health -= Damage;
	}


	void Update()
	{
		if(Health <= 0.0f)
		{
			DefeatEnemy();
		}

		CheckForDamage();
	}


	void FixedUpdate()
	{

		EnemyBehaviour();
	}


	void DefeatEnemy()
	{
		animator.SetTrigger(Hash.Animations.Enemies.Die_Trigger);

		ManageEnemyTypeDeath();


	}

	void Attack()
	{
		animator.SetTrigger(Hash.Animations.Enemies.Attack_Trigger);
	}

	void DisableAnimations()
	{
		animator.enabled = false;
	}

	void Turn()
	{
		Vector3 newScale = transform.localScale;
		newScale.x = newScale.x *-1;
		transform.localScale = newScale;

	}

	void EnableHazard()
	{
		hazard.enabled = true;
	}

	void DisableHazard()
	{
		hazard.enabled = false;
	}


	void EnemyBehaviour()
	{
		if(visionCone.GameObjectWithinVision.Contains(myPlayer.gameObject))
		{
			attack = true;
		}

		if(attack)
		{
			Attack();

			attack = !attack;
		}

		if(turn)
		{
			Turn();
			
			turn = !turn;
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{

		//Debug.Log(col.name);

//		if(col.gameObject.GetComponent<BulletPrefab>())
//		{
//			Destroy(col);
//		}
	}

	void ManageEnemyTypeDeath()
	{

		switch(myEnemyType)

		{
			case EnemyType.Dimetrodon:
				enemyBodyCollider.isTrigger = false;
				break;


		}

	}


}
