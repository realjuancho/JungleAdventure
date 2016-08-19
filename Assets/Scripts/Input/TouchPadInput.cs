using UnityEngine;
using System.Collections;

public class TouchPadInput : MonoBehaviour {

	
	GameObject originPoint;
	GameObject finalPoint;

	Player playerToControl; 

	void Start()
	{
		originPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
		originPoint.GetComponent<MeshRenderer>().enabled = true;
		originPoint.transform.SetParent(Camera.main.transform);
		originPoint.SetActive (false);

		finalPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere); 
		finalPoint.GetComponent<MeshRenderer>().enabled = true;
		originPoint.transform.SetParent(Camera.main.transform);
		finalPoint.SetActive (false);

		playerToControl =  GameObject.FindObjectOfType<Player>();

	}

	Vector3 positionInWorldPoints;
	void FixedUpdate()
	{
		CheckForMovementTouch();

		ResetButtons();
	}


	bool isMovementFingerOn;
	void CheckForMovementTouch()
	{
		#region MovementInput
		if(Input.touches.Length > 0)
		{
		 	Touch touch = Input.GetTouch(0);
			positionInWorldPoints = Camera.main.ScreenToWorldPoint(touch.position);
			if(touch.position.x < Screen.width /2)
			{
				isMovementFingerOn = true;
				ActivateTouchFrame(true);

				finalPoint.transform.position = new Vector3(positionInWorldPoints.x, positionInWorldPoints.y, 0.0f);

			}
			else
			{
				isMovementFingerOn = false;
				ActivateTouchFrame(isMovementFingerOn);
			}
		}
		else
		{
			isMovementFingerOn = false;
			ActivateTouchFrame(isMovementFingerOn);
		}


		if(originPoint)
		{
			if(originPoint.activeInHierarchy && finalPoint.activeInHierarchy)
			{
				Vector3 offset =  finalPoint.transform.position -originPoint.transform.position;

				float distance = offset.magnitude;

				Vector3 direction = offset / distance;

				float x = direction.x;
				float y = direction.y;

				MovementAxis_Horizontal = x;
				MovementAxis_Vertical = y;
			}
			else
			{
				MovementAxis_Horizontal = 0.0f;
				MovementAxis_Vertical = 0.0f;
			}
		}
		#endregion


	}

	void ActivateTouchFrame(bool Activate)
	{
		if(Activate && !originPoint.activeInHierarchy && !finalPoint.activeInHierarchy)
		{
			originPoint.SetActive(true);
			finalPoint.SetActive(true);

			//0.3f Magic Number: means the origin will be positioned a little bit below, since don't want to catch an unintended crouch position
			originPoint.transform.position = new Vector3(positionInWorldPoints.x, positionInWorldPoints.y -0.3f, 0.0f);
		}
		else if(!Activate)
		{
			if(originPoint)
			{
				originPoint.SetActive(false);
			}
			if(finalPoint)
			{
				finalPoint.SetActive(false);
			}
		}
	}


	public void CheckForButtonInput(int ButtonNumber)
	{
		if(ButtonNumber == 1) Button1 = true; else Button1 = false; 
		if(ButtonNumber == 2) Button2 = true; else Button2 = false; 
		if(ButtonNumber == 3) Button3 = true; else Button3 = false;
		if(ButtonNumber == 4) Button4 = true; else Button4 = false;
		if(ButtonNumber == 5) Button5 = true; else Button5 = false;
		if(ButtonNumber == 6) Button6 = true; else Button6 = false;
		if(ButtonNumber == 7) Button7 = true; else Button7 = false;
		if(ButtonNumber == 8) Button8 = true; else Button8 = false;
		if(ButtonNumber == 9) Button9 = true; else Button9 = false;
	}

	void ResetButtons()
	{
		Button1 = false;
		Button2 = false;
		Button3 = false;
		Button4 = false;
		Button5 = false;
		Button6 = false;
		Button7 = false;
		Button8 = false;
		Button9 = false;
	}

	public static float MovementAxis_Vertical;
	public static float MovementAxis_Horizontal;

	public static bool Button1;
	public static bool Button2;
	public static bool Button3;
	public static bool Button4;

	public static bool Button5;
	public static bool Button6;
	public static bool Button7;
	public static bool Button8;
	public static bool Button9;
}
