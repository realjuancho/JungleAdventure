using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPrefab : MonoBehaviour {


	public float bulletDamage = 10.0f;
	public List<GameObject> objectsCollided;

	public Shoot.ShootElement shootElement;

	void Awake()
	{
		objectsCollided = new List<GameObject>();

		gameObject.layer = LayerMask.NameToLayer(Hash.Layers.Bullets);


	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log(col.gameObject.name);

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

	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log(col.gameObject.name);

		if(!col.gameObject.GetComponent<Player>())
		{
			objectsCollided.Add(col.gameObject);
			Destroy(gameObject);
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
					e.inflictDamage(bulletDamage, shootElement);
				}
			}
		}
	}
}
