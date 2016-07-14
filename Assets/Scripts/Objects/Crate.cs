using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour {

	public enum CrateLoot { Coins, FirePickup, IcePickup, LightningPickup, EarthPickup }

	public HealthPoints hp;
	public bool killCrate = false;
	public CrateLoot crateLoots;
	public int lootQuantity = 10;

	Fraction[] fractions;
	float timeSinceKilled = 0.0f;
	float timeToDisappear = 3.0f;
	bool disableCrate;

	SoundEffects soundEffects;


	void Awake()
	{
		hp = GetComponent<HealthPoints>();

		fractions = GetComponentsInChildren<Fraction>(true);

		soundEffects = GetComponent<SoundEffects>();
	}


	void Update()
	{

		CheckForHealth();

	}


	void CheckForHealth()
	{
		if (hp.isDead && !disableCrate) 
		{
			killCrate = true;
			if(killCrate)
			{
				GetComponent<SpriteRenderer>().enabled = false;

				//Play breaking sound
				AudioSource.PlayClipAtPoint(soundEffects.audioClips[2], gameObject.transform.position);


				Destroy(gameObject.GetComponent<Rigidbody2D>());
				Destroy(gameObject.GetComponent<BoxCollider2D>());

				Loot();
			}

			foreach(Fraction f in fractions)
			{
				f.gameObject.SetActive(true);
			}

			disableCrate = true;
		}

		if(disableCrate)
		{
			timeSinceKilled += Time.deltaTime;

			if(timeSinceKilled >= timeToDisappear)
			{
				Destroy(gameObject);
			}

		}

	}



	void Loot()
	{
		for(int i = 0; i < lootQuantity; i++)
		{
			 ((GameObject)Instantiate(Resources.Load(Hash.Loot.Coin))).transform.position = transform.TransformPoint(Vector3.up * Random.Range(-0.0f,1.5f ));
		}
	}




	void OnCollisionEnter2D(Collision2D col)
	{

		//If Crate is Shot
		if(col.collider.GetComponent<BulletPrefab>())
		{
			if(!killCrate)
				AudioSource.PlayClipAtPoint(soundEffects.audioClips[0], transform.position);
		}
		else if(col.collider.GetComponent<LevelLayout>())
		{
			
		}
	}

}
