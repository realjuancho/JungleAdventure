using UnityEngine;
using System.Collections;

public class GrabObjectCheck : MonoBehaviour {


	Grabbable objectInHand;

	Transform originalParent;

	// Use this for initialization
	void Start () {

		originalParent = GameObject.Find("Objects").transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown(Hash.Buttons.Circle) || TouchPadInput.Button9 )
		{

			if(!objectInHand)
			{
				if(FindGrabbable())
				{
					GrabObject(grabbedObjectFound);
				}
			}
			else
			{
				ReleaseObject();
			}
		}
	}


	Grabbable grabbedObjectFound;
	bool FindGrabbable()
	{

		Collider2D[] colArr = Physics2D.OverlapCircleAll(transform.position, 1.0f);

		Debug.Log("Checking for grabbable! in " + LayerMask.NameToLayer(Hash.Layers.Grabbables));

		foreach(Collider2D col in colArr)
		{
			if(col)
			{
				grabbedObjectFound = col.GetComponent<Grabbable>();

				if(grabbedObjectFound)
				{
					Debug.Log(col.name + " found");
					return true;
				}
			}
		}

		return false;
	}

	float originalJumpForce;
	void GrabObject(Grabbable grabbedObject)
	{
		if(!objectInHand)
		{
			if(grabbedObject)
			{
				if(grabbedObject.myGrabbableSize == Grabbable.GrabbableSize.Small)
				{
					objectInHand = grabbedObject;

					grabbedObject.transform.SetParent(transform);

					grabbedObject.transform.position = transform.position;

					grabbedObject.GetComponent<BoxCollider2D>();

					Destroy(grabbedObject.GetComponent<Rigidbody2D>());

				}
				else if (grabbedObject.myGrabbableSize == Grabbable.GrabbableSize.Big)
				{
					objectInHand = grabbedObject;

					grabbedObject.transform.SetParent(transform);
					grabbedObject.transform.position = transform.position;

					grabbedObject.GetComponent<BoxCollider2D>();

					Destroy(grabbedObject.GetComponent<Rigidbody2D>());

					UnityStandardAssets._2D.PlatformerCharacter2D _pc2d = gameObject.GetComponentInParent<UnityStandardAssets._2D.PlatformerCharacter2D>();
					originalJumpForce = _pc2d.m_JumpForce;
					_pc2d.m_JumpForce /= 2; 
				}

			}
		}
	}

	void ReleaseObject()
	{
		if(objectInHand)
		{
			if(grabbedObjectFound)
			{

				grabbedObjectFound.transform.SetParent(originalParent);

				grabbedObjectFound.gameObject.AddComponent<Rigidbody2D>();

				if(originalJumpForce > 0)
				{
				UnityStandardAssets._2D.PlatformerCharacter2D _pc2d = gameObject.GetComponentInParent<UnityStandardAssets._2D.PlatformerCharacter2D>();
				_pc2d.m_JumpForce =	originalJumpForce;
				}	 
			}

			objectInHand = null;

		}
	}
	
}
