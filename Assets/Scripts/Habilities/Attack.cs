using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attack : MonoBehaviour{

		public enum AttackType { Upwards, Downwards, Forward, Backward, Area, Remote }
		public enum AttackForm { Physical, Elemental }
		public enum AttackElement { Brutal, Fire, Ice, Earth, Lightning }

		public AttackType attackType = AttackType.Forward;
		public AttackForm attackForm = AttackForm.Physical;
		public AttackElement attackElement = AttackElement.Brutal;

		//public float attackDuration = 5.0f;
		public float attackDuration = 0.3f;
		public float attackDamage = 10.0f;
		public float attackRatio = 0.3f;

		public List<GameObject> objectsCollided;

		public bool facingRight = true;


		public Attack()
		{}

		public Attack(AttackType myAttackType)
		{} 

		public Attack(AttackType myAttackType, AttackForm myAttackForm)
		{} 

		public Attack(AttackType myAttackType, AttackForm myAttackForm, AttackElement myAttackElement)
		{} 

		public Attack(AttackType myAttackType,  AttackForm myAttackForm, AttackElement myAttackElement, float myDuration)
		{} 


		void Start()
		{
			SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer> ();
			Sprite s;
			switch(attackElement)
			{
				case AttackElement.Brutal:
							s = Resources.Load<Sprite> (Hash.Sprites.AttackSprites.SimpleAttack);
					break;
				case AttackElement.Fire:
							s = Resources.Load<Sprite> (Hash.Sprites.AttackSprites.FireAttack);
							break;
				case AttackElement.Ice:
							s = Resources.Load<Sprite> (Hash.Sprites.AttackSprites.IceAttack);
							break;
				case AttackElement.Lightning:
							s = Resources.Load<Sprite> (Hash.Sprites.AttackSprites.LightningAttack);
							break;
				case AttackElement.Earth:
							s = Resources.Load<Sprite> (Hash.Sprites.AttackSprites.EarthAttack);
							break;
				default:
					s = Resources.Load<Sprite> (Hash.Sprites.AttackSprites.SimpleAttack);
					break;

			}

			sr.flipX = !facingRight;
			sr.sprite = s;

		
//			switch(attackElement)
//			{
//				case AttackElement.Brutal:
//					Instantiate(Resources.Load(Hash.Particles.AttackParticles.SimpleAttack));
//					break;
//				case AttackElement.Fire:
//					Instantiate(Resources.Load(Hash.Particles.AttackParticles.FireAttack));
//					break;
//				case AttackElement.Ice:
//					Instantiate(Resources.Load(Hash.Particles.AttackParticles.IceAttack));
//						break;
//				case AttackElement.Lightning:
//					Instantiate(Resources.Load(Hash.Particles.AttackParticles.LightningAttack));
//					break;
//				case AttackElement.Earth:
//					Instantiate(Resources.Load(Hash.Particles.AttackParticles.EarthAttack));
//					break;
//			}
		}

		float timeSinceInvoked = 0.0f;
		void Update()
		{


			Vector3 attackDirection = Vector3.forward;

			switch(attackType)
			{
				case AttackType.Forward:
					 if(facingRight) attackDirection =  transform.position + Vector3.right * 3.0f;
					else attackDirection =  transform.position + Vector3.left * 3.0f;
				break;

				case AttackType.Backward:
					if(facingRight) attackDirection =  transform.position + Vector3.left * 3.0f;
					else attackDirection =  transform.position + Vector3.right * 3.0f;
							
						break;
				case AttackType.Upwards:
					if(facingRight) attackDirection =  transform.position + Vector3.up * 3.0f;
					else attackDirection =  transform.position + Vector3.up * 3.0f;
							
						break;

			} 

			transform.position = Vector3.Lerp(transform.position, attackDirection, Time.deltaTime);




			if(timeSinceInvoked < attackDuration)
				timeSinceInvoked += Time.deltaTime;
			else
				Destroy(gameObject);
		}

		void Awake()
		{
			 BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
			 collider.isTrigger = true;

			 objectsCollided = new List<GameObject>();
		}

		void OnTriggerEnter2D(Collider2D col)
		{
			if(col.gameObject)
			{
				if(col.gameObject.GetComponentInParent<Enemy>() && !objectsCollided.Contains(col.gameObject) 
					&& (col.gameObject.layer == LayerMask.NameToLayer(Hash.Layers.EnemyBody))
					)
				{
					objectsCollided.Add(col.gameObject);
				}
			}
		}

		void OnDestroy()
		{
			foreach(GameObject g in objectsCollided)
			{
				if(g)
				{
					Enemy e = g.GetComponentInParent<Enemy>();
					if(e)
					{
						Debug.Log(e.gameObject.layer == LayerMask.NameToLayer(Hash.Layers.EnemyBody));
						e.inflictDamage(attackDamage);
					}
				}
			}
		}
	}