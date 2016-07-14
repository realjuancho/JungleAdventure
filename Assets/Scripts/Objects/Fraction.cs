using UnityEngine;
using System.Collections;

public class Fraction : MonoBehaviour {


	SpriteRenderer sr;

	// Use this for initialization

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	void Update ()
	 {

	 	if(gameObject.activeSelf)
	     	StartCoroutine(FadeTo(0.0f, 1.0f));

	 }
	 
	 IEnumerator FadeTo(float aValue, float aTime)
	 {
	     float alpha = sr.color.a;
	     for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
	     {
	         Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
	         sr.color = newColor;
	         yield return null;
	     }
	 }
}
