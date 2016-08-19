using UnityEngine;
using System.Collections;

public class Muzzle : MonoBehaviour {

	// Use this for initialization

	public Transform muzzlePosition;
	public GameObject[] muzzleFlashArray;


	void Start () {


	}
	
	// Update is called once per frame
	void Update () {

		

	}

	public void DisplayMuzzleAt(int index, bool notInverted)
	{
		GameObject go = ((GameObject)Instantiate(muzzleFlashArray[index], muzzlePosition.position, Quaternion.identity));
		go.GetComponent<SpriteRenderer>().flipX = !notInverted;
		go.transform.SetParent(muzzlePosition);
		Destroy(go,2.0f);

	}
}
