using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public enum EnemyType { Dimetrodon };

	public float Health = 100.0f;
	public EnemyType myEnemyType;


	VisionCone visionCone;
	Player myPlayer;
	PolygonCollider2D enemyBodyCollider;

    [SerializeField] bool turn;
  	[SerializeField] bool attack;


	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();	
		visionCone = GetComponentInChildren<VisionCone>();
		myPlayer = GameObject.FindObjectOfType<Player>();
		enemyBodyCollider =  gameObject.GetComponent<PolygonCollider2D>();

	}

	public void inflictDamage(float Damage)
	{
		Health -= Damage;
	}

	void Update()
	{
		if(Health <= 0.0f)
		{
			DefeatEnemy();
		}

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


	void EnemyBehaviour()
	{
		
			
		if(visionCone.GameObjectWithinVision.Contains(myPlayer.gameObject))
		{
			attack = true;
		}
	


		if(turn)
		{
			Turn();
			
			turn = !turn;
		}

		if(attack)
		{

			Attack();

			attack = !attack;
		}


	}


	void OnTriggerEnter2D(Collider2D col)
	{

		Debug.Log(col.name);
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
