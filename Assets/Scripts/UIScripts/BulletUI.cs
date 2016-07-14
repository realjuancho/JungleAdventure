using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletUI : MonoBehaviour {


	public Sprite[] myImages;
	Image myImage;

	// Use this for initialization
	void Start () {
		myImage = gameObject.GetComponent<Image>();
	
	}
	
	// Update is called once per frame
	void Update () {


		int i = GameManager.GetBulletsLeft();

		switch (i)
		{
			case 5:
				myImage.sprite = myImages[0];
			break;

			case 4:
					myImage.sprite = myImages[1];
				break;

			case 3:
					myImage.sprite = myImages[2];
				break;

			case 2:
					myImage.sprite = myImages[3];
					break;

			case 1:
					myImage.sprite = myImages[4];
				break;

			case 0:
					myImage.sprite = myImages[5];
				break;

		}
	}
}
