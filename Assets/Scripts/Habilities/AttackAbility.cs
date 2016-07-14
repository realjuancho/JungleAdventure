using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
using System.Collections.Generic;

public class AttackAbility : MonoBehaviour {


	public float coolDownAttackTime = 1.0f;
	public int rateOfFire = 3;

	public bool fireAttackEnabled = false;
	public bool iceAttackEnabled = false;
	public bool lightningAttackEnabled = false;
	public bool earthAttackEnabled = false;

	public float fireAttackHealth = 0.0f;
	public float iceAttackHealth = 0.0f;
	public float lightningAttackHealth = 0.0f;
	public float earthAttackHealth = 0.0f;

	public Attack.AttackElement selectedElement = Attack.AttackElement.Brutal;
	float timeSinceLastAttack = 0.0f;
	int fireCount;
	bool attackDisabled = false;

	//Necesitado para saber si el jugador ve a la izquierda o la derecha.
	UnityStandardAssets._2D.PlatformerCharacter2D character;

	void Start()
	{
		character = GetComponentInParent<UnityStandardAssets._2D.PlatformerCharacter2D>();
	}

	// Update is called once per frame



	void Update () {
	#region Test Input DS4
	/*
	#region face buttons
		if(Input.GetButtonDown(Hash.Buttons.Square))
			{
				Debug.Log("Square");

			}
		if(Input.GetButtonDown(Hash.Buttons.Triangle))
			{
				Debug.Log("Triangle");

			}
		if(Input.GetButtonDown(Hash.Buttons.Circle))
			{
				Debug.Log("Circle");

			}
		if(Input.GetButtonDown(Hash.Buttons.Cross))
			{
				Debug.Log("Cross");

			}
	#endregion

	#region L and R Buttons (1,2,3)
		if (Input.GetButtonDown (Hash.Buttons.L1_Button)) {
			Debug.Log ("L1 Button");

		}
		if (Input.GetButtonDown (Hash.Buttons.R1_Button)) {
			Debug.Log ("R1 Button");

		}
		if (Input.GetButtonDown (Hash.Buttons.L2_Button)) {
			Debug.Log ("L2 Button");

		}
		if (Input.GetButtonDown (Hash.Buttons.R2_Button)) {
			Debug.Log ("R2 Button");

		}


		if (Input.GetButtonDown (Hash.Buttons.L3_Button)) {
			Debug.Log ("L3 Button");

		}
		if (Input.GetButtonDown (Hash.Buttons.R3_Button)) {
			Debug.Log ("R3 Button");

		}
		#endregion

	#region Share,Options,TouchPad
		if (Input.GetButtonDown (Hash.Buttons.Options)) {
			Debug.Log ("Options");

		}
		if (Input.GetButtonDown (Hash.Buttons.Share)) {
			Debug.Log ("Share");

		}
		if (Input.GetButtonDown (Hash.Buttons.TouchPadClick)) {
			Debug.Log ("Touch Pad Click");

		}
		if (Input.GetButtonDown (Hash.Buttons.PSButton)) {
			Debug.Log ("PS Button");

		}
		#endregion
	
	#region DPAD AXIS
		if (Input.GetAxis (Hash.Axis.DPad_LeftRight) > 0) {
			Debug.Log ("DPad Right");

		}
		if (Input.GetAxis (Hash.Axis.DPad_LeftRight) < 0) {
			Debug.Log ("DPad Left");

		}

		if (Input.GetAxis (Hash.Axis.DPad_UpDown) > 0) {
			Debug.Log ("DPad Down");

		}
		if (Input.GetAxis (Hash.Axis.DPad_UpDown) < 0) {
			Debug.Log ("DPad Up");

		}
		#endregion

	#region Joystick Axis

		if (Input.GetAxis (Hash.Axis.LStick_UpDown) > 0) {
			//Debug.Log ("LStick Up: " + Input.GetAxis (Hash.Axis.LStick_UpDown));
			Debug.Log ("LStick Down");
		}
		if (Input.GetAxis (Hash.Axis.LStick_UpDown) < 0) {
			//Debug.Log ("LStick Down: " + Input.GetAxis (Hash.Axis.LStick_UpDown));
			Debug.Log ("LStick Up");
		}

		if (Input.GetAxis (Hash.Axis.LStick_LeftRight) > 0) {
			//Debug.Log ("LStick Right: " + Input.GetAxis (Hash.Axis.LStick_LeftRight));
			Debug.Log ("LStick Right");
		}
		if (Input.GetAxis (Hash.Axis.LStick_LeftRight) < 0) {
			//Debug.Log ("LStick Left: " + Input.GetAxis (Hash.Axis.LStick_LeftRight)  );
			Debug.Log ("LStick Left");
		}


		if (Input.GetAxis (Hash.Axis.RStick_UpDown) > 0) {
			//Debug.Log ("LStick Up: " + Input.GetAxis (Hash.Axis.LStick_UpDown));
			Debug.Log ("RStick Down");
		}
		if (Input.GetAxis (Hash.Axis.RStick_UpDown) < 0) {
			//Debug.Log ("LStick Down: " + Input.GetAxis (Hash.Axis.LStick_UpDown));
			Debug.Log ("RStick Up");
		}

		if (Input.GetAxis (Hash.Axis.RStick_LeftRight) > 0) {
			//Debug.Log ("LStick Right: " + Input.GetAxis (Hash.Axis.LStick_LeftRight));
			Debug.Log ("RStick Right");
		}
		if (Input.GetAxis (Hash.Axis.RStick_LeftRight) < 0) {
			//Debug.Log ("LStick Left: " + Input.GetAxis (Hash.Axis.LStick_LeftRight)  );
			Debug.Log ("RStick Left");
		}


	
		#endregion
		*/
		#endregion


		SelectElements ();


		AttackInput ();

		CheckAttackHealth();
	}

	enum PadDirection { idle, up, down, left, right };
	bool selectionFrame = false;
	PadDirection myPadDirection;

	void SelectElements ()
	{

	 	myPadDirection = PadDirection.idle;

	 	#region Dualshock4
//	 	if(!selectionFrame)
//		if(Input.GetAxis(Hash.Axis.DPad_UpDown) < 0) {myPadDirection = PadDirection.up;  selectionFrame = true; }
//		else if(Input.GetAxis(Hash.Axis.DPad_UpDown) > 0) {myPadDirection = PadDirection.down;  selectionFrame = true; }
//		else if(Input.GetAxis(Hash.Axis.DPad_LeftRight) < 0) {myPadDirection = PadDirection.left;  selectionFrame = true; }
//		else if(Input.GetAxis(Hash.Axis.DPad_LeftRight) > 0) {myPadDirection = PadDirection.right;  selectionFrame = true; }
//
//
//		if(selectionFrame)
//		{
//			switch(selectedElement)
//			{
//				case Attack.AttackElement.Brutal:
//					if(myPadDirection == PadDirection.up && lightningAttackEnabled) selectedElement = Attack.AttackElement.Lightning;
//					else if(myPadDirection == PadDirection.down && earthAttackEnabled) selectedElement = Attack.AttackElement.Earth;
//					else if(myPadDirection == PadDirection.left && iceAttackEnabled) selectedElement = Attack.AttackElement.Ice;
//					else if(myPadDirection == PadDirection.right && fireAttackEnabled) selectedElement = Attack.AttackElement.Fire;
//				break;
//				case Attack.AttackElement.Earth:
//					if(myPadDirection == PadDirection.up) selectedElement = Attack.AttackElement.Brutal;
//					else if(myPadDirection == PadDirection.right && fireAttackEnabled) selectedElement = Attack.AttackElement.Fire;
//					else if(myPadDirection == PadDirection.left && fireAttackEnabled) selectedElement = Attack.AttackElement.Ice;
//				break;
//				case Attack.AttackElement.Fire:
//					if(myPadDirection == PadDirection.left) selectedElement = Attack.AttackElement.Brutal;
//					else if(myPadDirection == PadDirection.up && lightningAttackEnabled) selectedElement = Attack.AttackElement.Lightning;
//					else if(myPadDirection == PadDirection.down && earthAttackEnabled) selectedElement = Attack.AttackElement.Earth;
//				break;
//				case Attack.AttackElement.Ice:
//					if(myPadDirection == PadDirection.right) selectedElement = Attack.AttackElement.Brutal;
//					else if(myPadDirection == PadDirection.up && lightningAttackEnabled) selectedElement = Attack.AttackElement.Lightning;
//					else if(myPadDirection == PadDirection.down && earthAttackEnabled) selectedElement = Attack.AttackElement.Earth;
//				break;
//				case Attack.AttackElement.Lightning:
//				if(myPadDirection == PadDirection.down) selectedElement = Attack.AttackElement.Brutal;
//					else if(myPadDirection == PadDirection.left && iceAttackEnabled) selectedElement = Attack.AttackElement.Ice;
//					else if(myPadDirection == PadDirection.right && fireAttackEnabled) selectedElement = Attack.AttackElement.Fire;
//				break;
//
//			}
//		}
//		if(Input.GetAxis(Hash.Axis.DPad_LeftRight) != 0 ||  (Input.GetAxis(Hash.Axis.DPad_UpDown) != 0)) selectionFrame = true;
//		else selectionFrame = false;
		#endregion 

		#region Keyboard

		if(!selectionFrame)
		if(Input.GetKeyDown(KeyCode.UpArrow)) {myPadDirection = PadDirection.up;  selectionFrame = true; }
		else if(Input.GetKeyDown(KeyCode.DownArrow)) {myPadDirection = PadDirection.down;  selectionFrame = true; }
		else if(Input.GetKeyDown(KeyCode.LeftArrow)) {myPadDirection = PadDirection.left;  selectionFrame = true; }
		else if(Input.GetKeyDown(KeyCode.RightArrow)) {myPadDirection = PadDirection.right;  selectionFrame = true; }


		if(selectionFrame)
		{
			switch(selectedElement)
			{
				case Attack.AttackElement.Brutal:
					if(myPadDirection == PadDirection.up && lightningAttackEnabled) selectedElement = Attack.AttackElement.Lightning;
					else if(myPadDirection == PadDirection.down && earthAttackEnabled) selectedElement = Attack.AttackElement.Earth;
					else if(myPadDirection == PadDirection.left && iceAttackEnabled) selectedElement = Attack.AttackElement.Ice;
					else if(myPadDirection == PadDirection.right && fireAttackEnabled) selectedElement = Attack.AttackElement.Fire;
				break;
				case Attack.AttackElement.Earth:
					if(myPadDirection == PadDirection.up) selectedElement = Attack.AttackElement.Brutal;
					else if(myPadDirection == PadDirection.right && fireAttackEnabled) selectedElement = Attack.AttackElement.Fire;
					else if(myPadDirection == PadDirection.left && fireAttackEnabled) selectedElement = Attack.AttackElement.Ice;
				break;
				case Attack.AttackElement.Fire:
					if(myPadDirection == PadDirection.left) selectedElement = Attack.AttackElement.Brutal;
					else if(myPadDirection == PadDirection.up && lightningAttackEnabled) selectedElement = Attack.AttackElement.Lightning;
					else if(myPadDirection == PadDirection.down && earthAttackEnabled) selectedElement = Attack.AttackElement.Earth;
				break;
				case Attack.AttackElement.Ice:
					if(myPadDirection == PadDirection.right) selectedElement = Attack.AttackElement.Brutal;
					else if(myPadDirection == PadDirection.up && lightningAttackEnabled) selectedElement = Attack.AttackElement.Lightning;
					else if(myPadDirection == PadDirection.down && earthAttackEnabled) selectedElement = Attack.AttackElement.Earth;
				break;
				case Attack.AttackElement.Lightning:
				if(myPadDirection == PadDirection.down) selectedElement = Attack.AttackElement.Brutal;
					else if(myPadDirection == PadDirection.left && iceAttackEnabled) selectedElement = Attack.AttackElement.Ice;
					else if(myPadDirection == PadDirection.right && fireAttackEnabled) selectedElement = Attack.AttackElement.Fire;
				break;

			}
		}
		if(Input.GetKeyDown(KeyCode.UpArrow) ||Input.GetKeyDown(KeyCode.DownArrow) || 
			Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) selectionFrame = true;
		else selectionFrame = false;

		#endregion

		#region Touch Controls
//		if(TouchPadInput.Button1) { Debug.Log("Lightning");
//			if(lightningAttackEnabled) selectedElement = Attack.AttackElement.Lightning; 
//			else selectedElement = Attack.AttackElement.Brutal;
//		  }
//		else if(TouchPadInput.Button2) { Debug.Log("Earth");
//			if(earthAttackEnabled) selectedElement = Attack.AttackElement.Earth; 
//			else selectedElement = Attack.AttackElement.Brutal;
//		  }
//		else if(TouchPadInput.Button3) { Debug.Log("Ice");
//			if(iceAttackEnabled) selectedElement = Attack.AttackElement.Ice; 
//			else selectedElement = Attack.AttackElement.Brutal;
//		  }
//		else if(TouchPadInput.Button4) {  Debug.Log("Fire");
//			if(fireAttackEnabled) selectedElement = Attack.AttackElement.Fire; 
//			else selectedElement = Attack.AttackElement.Brutal;
//		  }
//		else if(TouchPadInput.Button5) {  Debug.Log("Brutal");
//			selectedElement = Attack.AttackElement.Brutal;
//		  }


		#endregion

	}


	void AttackInput ()
	{
		bool attackFrame = false;
		if (!attackDisabled) {
			if (Input.GetButtonDown (Hash.Buttons.Square) || TouchPadInput.Button6 || Input.GetKeyDown(KeyCode.K)) {
				ForwardAttack ();
				attackFrame = true;
			}
			if (Input.GetButtonDown (Hash.Buttons.Triangle) || TouchPadInput.Button7 || Input.GetKeyDown(KeyCode.O)) {
				UpwardAttack ();
				attackFrame = true;
			}
			if (attackFrame) {
				fireCount++;
				if (fireCount >= rateOfFire) {
					attackDisabled = true;
					timeSinceLastAttack = 0.0f;
					fireCount = 0;
				}
				UseAttackHealth();
			}
		}
		else {
			timeSinceLastAttack += Time.deltaTime;
			if (timeSinceLastAttack >= coolDownAttackTime)
				attackDisabled = false;
		}
	}


	void ForwardAttack ()
	{
		GameObject go = new GameObject ("Forward_Attack");
		go.transform.parent = gameObject.transform;
		go.transform.position = gameObject.transform.position;
		Attack a = go.AddComponent<Attack> ();
		a.attackElement =selectedElement;
		a.facingRight = character.isFacingRight;
		a.attackType = Attack.AttackType.Forward;
		character.Melee();
	}

	void UpwardAttack ()
	{
		GameObject go = new GameObject ("Upward_Attack");
		go.transform.parent = gameObject.transform;
		go.transform.position = gameObject.transform.position;
		Attack a = go.AddComponent<Attack> ();
		a.attackElement =selectedElement;
		a.facingRight = character.isFacingRight;
		a.attackType = Attack.AttackType.Upwards;
		character.Melee();
	}

	void UseAttackHealth()
	{
		switch(selectedElement)
		{
			case Attack.AttackElement.Earth:
				earthAttackHealth--; 
				if(earthAttackHealth <=0) { earthAttackEnabled = false; selectedElement = Attack.AttackElement.Brutal;}
				break;
			case Attack.AttackElement.Fire:
				fireAttackHealth--;
				if(fireAttackHealth <=0) { fireAttackEnabled = false; selectedElement = Attack.AttackElement.Brutal;}
				break;
			case Attack.AttackElement.Lightning:
				lightningAttackHealth--;
			if(lightningAttackHealth <=0) { lightningAttackEnabled = false; selectedElement = Attack.AttackElement.Brutal;}
				break;
			case Attack.AttackElement.Ice:
				iceAttackHealth--;
				if(iceAttackHealth <=0) { iceAttackEnabled = false; selectedElement = Attack.AttackElement.Brutal;}
				break;
		}
	}

	public void AddAttackHealth(Attack.AttackElement attackElement, float Health)
	{
		switch(attackElement)
		{
			case Attack.AttackElement.Earth:
				earthAttackHealth+= Health; if(earthAttackHealth >= 0) earthAttackEnabled = true;
				break;
			case Attack.AttackElement.Ice:  
				iceAttackHealth+= Health;  if(iceAttackHealth >= 0) iceAttackEnabled = true;
				break;
			case Attack.AttackElement.Fire:
				fireAttackHealth+= Health; if(fireAttackHealth >= 0) fireAttackEnabled = true;
				break;
			case Attack.AttackElement.Lightning:
				lightningAttackHealth+= Health; if(lightningAttackHealth >= 0) lightningAttackEnabled = true;
				break;
		}
	}

	void CheckAttackHealth()
	{
		if(earthAttackHealth > 0.0f) earthAttackEnabled = true; else earthAttackEnabled = false;
		if(fireAttackHealth > 0.0f) fireAttackEnabled = true; else fireAttackEnabled = false;
		if(iceAttackHealth > 0.0f) iceAttackEnabled = true; else iceAttackEnabled = false;
		if(lightningAttackHealth > 0.0f) lightningAttackEnabled = true; else lightningAttackEnabled = false;

	}
}



