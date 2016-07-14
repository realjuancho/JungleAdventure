using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shoot : MonoBehaviour {

	public enum ShootEffect { Upwards, Downwards, Forward, Backward, Area, Remote }
	public enum ShootForm { Physical, Elemental }
	public enum ShootElement { Simple, Fire, Ice, Earth, Lightning }

	public ShootEffect shootType = ShootEffect.Forward;
	public ShootForm shootForm = ShootForm.Physical;
	public ShootElement shootElement = ShootElement.Simple;

	//public float attackDuration = 5.0f;
	public float bulletDuration = 0.3f;
	public float bulletDistance = 10.0f;
	public float fireRatio = 0.3f;
	public float bulletSpeed = 10.0f;


	public Vector3 shootDirection;


	public bool facingRight = true;

		void Start()
		{
			switch(shootElement)
			{
				case ShootElement.Simple:
					((GameObject)Instantiate(Resources.Load(Hash.Prefabs.Bullets.simpleBullet), transform.position, Quaternion.identity)).transform.parent = transform;
					break;
				case ShootElement.Fire:
							((GameObject)Instantiate(Resources.Load(Hash.Prefabs.Bullets.fireBullet), transform.position, Quaternion.identity)).transform.parent = transform;
							break;

				case ShootElement.Ice:
							((GameObject)Instantiate(Resources.Load(Hash.Prefabs.Bullets.iceBullet), transform.position, Quaternion.identity)).transform.parent = transform;
							break;

				case ShootElement.Lightning:
							((GameObject)Instantiate(Resources.Load(Hash.Prefabs.Bullets.lightningBullet), transform.position, Quaternion.identity)).transform.parent = transform;
							break;
				case ShootElement.Earth:
							((GameObject)Instantiate(Resources.Load(Hash.Prefabs.Bullets.earthBullet), transform.position, Quaternion.identity)).transform.parent = transform;
							break;
			}


		}

		float timeSinceInvoked = 0.0f;
		void Update()
		{
			Vector3 attackDirection = Vector3.forward;

			switch(shootType)
			{
				case ShootEffect.Forward:
					 if(facingRight) attackDirection =  transform.position + Vector3.right * bulletDistance;
					else attackDirection =  transform.position + Vector3.left * bulletDistance;

	
				break;

				case ShootEffect.Backward:
			if(facingRight) attackDirection =  transform.position + Vector3.left * bulletDistance;
			else attackDirection =  transform.position + Vector3.right * bulletDistance;
							
						break;
				case ShootEffect.Upwards:
			if(facingRight) attackDirection =  transform.position + Vector3.up * bulletDistance;
			else attackDirection =  transform.position + Vector3.up * bulletDistance;
							
						break;

			} 

			transform.position = Vector3.Lerp(transform.position, attackDirection, Time.deltaTime * bulletSpeed);


			if(timeSinceInvoked < bulletDuration)
				timeSinceInvoked += Time.deltaTime;
			else
				Destroy(gameObject);
		}


}
