using UnityEngine;
using System.Collections;

public class ShootingAbility : MonoBehaviour {

	public float reloadTime = 1.0f;
	public int magazineSize = 5;
	public int bulletsLeft;

	public bool fireShotEnabled = false;
	public bool iceShotEnabled = false;
	public bool lightningShotEnabled = false;
	public bool earthShotEnabled = false;

	public float shootingDistance = 10.0f;
	public float bulletSpeed = 5.0f;

	public float fireBullets = 0.0f;
	public float iceBullets = 0.0f;
	public float lightningBullets = 0.0f;
	public float earthBullets = 0.0f;

	public Shoot.ShootElement selectedElement;
	float timeSinceLastAttack = 0.0f;
	int fireCount;
	bool attackDisabled = false;
	GameObject shootDirection;


	SoundEffects soundEffects;

	//Necesitado para saber si el jugador ve a la izquierda o la derecha.
	UnityStandardAssets._2D.PlatformerCharacter2D character;

	void Start()
	{
		character = GetComponentInParent<UnityStandardAssets._2D.PlatformerCharacter2D>();


		soundEffects = GetComponent<SoundEffects>();

		shootDirection = transform.FindChild("ShootingDirection").gameObject;

	}

	void Update () {

		SelectElements ();


		AttackInput ();

		CheckAttackHealth();


		bulletsLeft = magazineSize - fireCount;

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
//				case global::Shoot.ShootElement.Simple:
//					if(myPadDirection == PadDirection.up && lightningShotEnabled) selectedElement = global::Shoot.ShootElement.Lightning;
//					else if(myPadDirection == PadDirection.down && earthShotEnabled) selectedElement = global::Shoot.ShootElement.Earth;
//					else if(myPadDirection == PadDirection.left && iceShotEnabled) selectedElement = global::Shoot.ShootElement.Ice;
//					else if(myPadDirection == PadDirection.right && fireShotEnabled) selectedElement = global::Shoot.ShootElement.Fire;
//				break;
//				case global::Shoot.ShootElement.Earth:
//					if(myPadDirection == PadDirection.up) selectedElement =global::Shoot.ShootElement.Simple;
//					else if(myPadDirection == PadDirection.right && fireShotEnabled) selectedElement = global::Shoot.ShootElement.Fire;
//					else if(myPadDirection == PadDirection.left && fireShotEnabled) selectedElement = global::Shoot.ShootElement.Ice;
//				break;
//				case global::Shoot.ShootElement.Fire:
//					if(myPadDirection == PadDirection.left) selectedElement =global::Shoot.ShootElement.Simple;
//					else if(myPadDirection == PadDirection.up && lightningShotEnabled) selectedElement = global::Shoot.ShootElement.Lightning;
//					else if(myPadDirection == PadDirection.down && earthShotEnabled) selectedElement = global::Shoot.ShootElement.Earth;
//				break;
//				case global::Shoot.ShootElement.Ice:
//					if(myPadDirection == PadDirection.right) selectedElement =global::Shoot.ShootElement.Simple;
//					else if(myPadDirection == PadDirection.up && lightningShotEnabled) selectedElement = global::Shoot.ShootElement.Lightning;
//					else if(myPadDirection == PadDirection.down && earthShotEnabled) selectedElement = global::Shoot.ShootElement.Earth;
//				break;
//				case global::Shoot.ShootElement.Lightning:
//				if(myPadDirection == PadDirection.down) selectedElement =global::Shoot.ShootElement.Simple;
//					else if(myPadDirection == PadDirection.left && iceShotEnabled) selectedElement = global::Shoot.ShootElement.Ice;
//					else if(myPadDirection == PadDirection.right && fireShotEnabled) selectedElement = global::Shoot.ShootElement.Fire;
//				break;
//
//			}
//		}
//		if(Input.GetAxis(Hash.Axis.DPad_LeftRight) != 0 ||  (Input.GetAxis(Hash.Axis.DPad_UpDown) != 0)) selectionFrame = true;
//		else selectionFrame = false;
		#endregion 

		#region Keyboard

//		if(!selectionFrame)
//		if(Input.GetKeyDown(KeyCode.UpArrow)) {myPadDirection = PadDirection.up;  selectionFrame = true; }
//		else if(Input.GetKeyDown(KeyCode.DownArrow)) {myPadDirection = PadDirection.down;  selectionFrame = true; }
//		else if(Input.GetKeyDown(KeyCode.LeftArrow)) {myPadDirection = PadDirection.left;  selectionFrame = true; }
//		else if(Input.GetKeyDown(KeyCode.RightArrow)) {myPadDirection = PadDirection.right;  selectionFrame = true; }
//
//
//		if(selectionFrame)
//		{
//			switch(selectedElement)
//			{
//				case global::Shoot.ShootElement.Simple:
//				if(myPadDirection == PadDirection.up && lightningShotEnabled) selectedElement = global::Shoot.ShootElement.Lightning;
//				else if(myPadDirection == PadDirection.down && earthShotEnabled) selectedElement =global::Shoot.ShootElement .Earth;
//				else if(myPadDirection == PadDirection.left && iceShotEnabled) selectedElement = global::Shoot.ShootElement.Ice;
//				else if(myPadDirection == PadDirection.right && fireShotEnabled) selectedElement = global::Shoot.ShootElement.Fire;
//				break;
//			case global::Shoot.ShootElement.Earth:
//					if(myPadDirection == PadDirection.up) selectedElement = global::Shoot.ShootElement.Simple;
//				else if(myPadDirection == PadDirection.right && fireShotEnabled) selectedElement = global::Shoot.ShootElement.Fire;
//				else if(myPadDirection == PadDirection.left && fireShotEnabled) selectedElement = global::Shoot.ShootElement.Ice;
//				break;
//			case global::Shoot.ShootElement.Fire:
//				if(myPadDirection == PadDirection.left) selectedElement = global::Shoot.ShootElement.Simple;
//				else if(myPadDirection == PadDirection.up && lightningShotEnabled) selectedElement = global::Shoot.ShootElement.Lightning;
//				else if(myPadDirection == PadDirection.down && earthShotEnabled) selectedElement = global::Shoot.ShootElement.Earth;
//				break;
//			case global::Shoot.ShootElement.Ice:
//				if(myPadDirection == PadDirection.right) selectedElement =global::Shoot.ShootElement.Simple;
//				else if(myPadDirection == PadDirection.up && lightningShotEnabled) selectedElement = global::Shoot.ShootElement.Lightning;
//				else if(myPadDirection == PadDirection.down && earthShotEnabled) selectedElement = global::Shoot.ShootElement.Earth;
//				break;
//			case global::Shoot.ShootElement.Lightning:
//				if(myPadDirection == PadDirection.down) selectedElement =global::Shoot.ShootElement.Simple;
//				else if(myPadDirection == PadDirection.left && iceShotEnabled) selectedElement = global::Shoot.ShootElement.Ice;
//				else if(myPadDirection == PadDirection.right && fireShotEnabled) selectedElement = global::Shoot.ShootElement.Fire;
//				break;
//
//			}
//		}
//		if(Input.GetKeyDown(KeyCode.UpArrow) ||Input.GetKeyDown(KeyCode.DownArrow) || 
//			Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) selectionFrame = true;
//		else selectionFrame = false;

		#endregion

		#region Touch Controls
		if(TouchPadInput.Button1) { Debug.Log("Lightning");
			if(lightningShotEnabled) selectedElement = global::Shoot.ShootElement.Lightning; 
			else selectedElement =global::Shoot.ShootElement.Simple;
		  }
		else if(TouchPadInput.Button2) { Debug.Log("Earth");
			if(earthShotEnabled) selectedElement = global::Shoot.ShootElement.Earth; 
			else selectedElement =global::Shoot.ShootElement.Simple;
		  }
		else if(TouchPadInput.Button3) { Debug.Log("Ice");
			if(iceShotEnabled) selectedElement = global::Shoot.ShootElement.Ice; 
			else selectedElement =global::Shoot.ShootElement.Simple;
		  }
		else if(TouchPadInput.Button4) {  Debug.Log("Fire");
			if(fireShotEnabled) selectedElement = global::Shoot.ShootElement.Fire; 
			else selectedElement = global::Shoot.ShootElement.Simple;
		  }
		else if(TouchPadInput.Button5) {  Debug.Log("Brutal");
			selectedElement =global::Shoot.ShootElement.Simple;
		  }


		#endregion

	}


	void AttackInput ()
	{
		bool attackFrame = false;
		if (!attackDisabled) {
			if (Input.GetButtonDown (Hash.Buttons.Square) || TouchPadInput.Button6 || Input.GetKeyDown(KeyCode.K)) {

				Shoot();

				attackFrame = true;
			}
			if (Input.GetButtonDown (Hash.Buttons.Triangle) || TouchPadInput.Button7 || Input.GetKeyDown(KeyCode.O)) {

				Melee ();

				attackFrame = true;
			}
			if (attackFrame) {
				fireCount++;
				if (fireCount >= magazineSize) {
					attackDisabled = true;
					timeSinceLastAttack = 0.0f;
				}
				UseAttackHealth();
			}
		}
		else {
			timeSinceLastAttack += Time.deltaTime;
			if (timeSinceLastAttack >= reloadTime)
			{
				attackDisabled = false;

				fireCount = 0;
			}
		}
	}


	void Shoot()
	{

		character.Shoot();




		GameObject go = new GameObject ("Shoot");
		//go.transform.parent = gameObject.transform;
		go.transform.position = gameObject.transform.position;


		Shoot a = go.AddComponent<Shoot> ();
		a.bulletDistance = shootingDistance;
		a.shootElement = selectedElement;
		a.facingRight = character.isFacingRight;
		a.bulletSpeed = bulletSpeed;
		a.shootDirection = shootDirection.transform.localPosition;
		a.shootType = global::Shoot.ShootEffect.Forward;


		AudioSource.PlayClipAtPoint(soundEffects.audioClips[0], transform.position);
	}

	void Melee ()
	{
//		GameObject go = new GameObject ("Upward_Attack");
//		go.transform.parent = gameObject.transform;
//		go.transform.position = gameObject.transform.position;
//		Shoot a = go.AddComponent<Shoot> ();
//		a.bulletDistance = shootingDistance;
//		a.shootElement =selectedElement;
//		a.facingRight = character.isFacingRight;
//		a.shootType = global::Shoot.ShootEffect.Upwards;
		character.Melee();
	}

	void UseAttackHealth()
	{
		switch(selectedElement)
		{
			case global::Shoot.ShootElement.Earth:
				earthBullets--; 
				if(earthBullets <=0) { earthShotEnabled = false; selectedElement = global::Shoot.ShootElement.Simple;}
				break;
		case global::Shoot.ShootElement.Fire:
				fireBullets--;
			if(fireBullets <=0) { fireShotEnabled = false; selectedElement =global::Shoot.ShootElement.Simple;}
				break;
		case global::Shoot.ShootElement.Lightning:
				lightningBullets--;
			if(lightningBullets <=0) { lightningShotEnabled = false; selectedElement =global::Shoot.ShootElement.Simple;}
				break;
		case global::Shoot.ShootElement.Ice:
				iceBullets--;
			if(iceBullets <=0) { iceShotEnabled = false; selectedElement =global::Shoot.ShootElement.Simple;}
				break;
		}
	}

	public void AddAttackHealth(Attack.AttackElement attackElement, float Health)
	{
		switch(attackElement)
		{
			case Attack.AttackElement.Earth:
				earthBullets+= Health; if(earthBullets >= 0) earthShotEnabled = true;
				break;
			case Attack.AttackElement.Ice:  
				iceBullets+= Health;  if(iceBullets >= 0) iceShotEnabled = true;
				break;
			case Attack.AttackElement.Fire:
			fireBullets+= Health; if(fireBullets >= 0) fireShotEnabled = true;
				break;
			case Attack.AttackElement.Lightning:
				lightningBullets+= Health; if(lightningBullets >= 0) lightningShotEnabled = true;
				break;
		}
	}

	void CheckAttackHealth()
	{
		if(earthBullets > 0.0f) earthShotEnabled = true; else earthShotEnabled = false;
		if(fireBullets > 0.0f) fireShotEnabled = true; else fireShotEnabled = false;
		if(iceBullets > 0.0f) iceShotEnabled = true; else iceShotEnabled = false;
		if(lightningBullets > 0.0f) lightningShotEnabled = true; else lightningShotEnabled = false;

	}



}
