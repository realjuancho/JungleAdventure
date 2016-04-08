using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {


	public enum PickupElement { Fire, Ice, Lightning, Earth, Money }
	public PickupElement pickupElement;

	public float pickupElementValue = 1.0f;


	AudioSource audioSource;

	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.GetComponent<PickupCheck>())
		{
			Debug.Log("Player");

			AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);

			Destroy(gameObject);
		}


	}



}
