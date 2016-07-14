using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerSelectorButton : MonoBehaviour {


	public Shoot.ShootElement attackSelector;
	//AttackAbility attackAbility;
	ShootingAbility shootingAbility;
	Text healthText;

	Image iconImage;
	Image contorno;

	bool showOutline;

	void Start()
	{
		//attackAbility = GameObject.FindObjectOfType<AttackAbility>();
		shootingAbility = GameObject.FindObjectOfType<ShootingAbility>();

		iconImage = GetComponent<Image>();
		contorno = gameObject.transform.FindChild("Contorno").GetComponent<Image>();

		showOutline = false;

		healthText = GetComponentInChildren<Text>();
	}


	void Update()
	{
		float unit = 155.0f / 1000.0f;


		/*Attack Ability
		switch(attackSelector)
		{
			case Attack.AttackElement.Lightning:
				healthText.text = shootingAbility.lightningBullets.ToString();
				iconImage.color = new Color(unit * shootingAbility.lightningBullets
					, unit * shootingAbility.lightningBullets
					, unit * shootingAbility.lightningBullets);
	
				break;
			case Attack.AttackElement.Ice:
				healthText.text = shootingAbility.iceBullets.ToString();
			iconImage.color = new Color(unit * shootingAbility.iceBullets
				, unit * shootingAbility.iceBullets
				, unit * shootingAbility.iceBullets);

				break;
			case Attack.AttackElement.Fire:
				healthText.text = shootingAbility.fireBullets.ToString();
			iconImage.color = new Color(unit * shootingAbility.fireBullets
				, unit * shootingAbility.fireBullets
				, unit * shootingAbility.fireBullets);
				break;
			case Attack.AttackElement.Earth:
				healthText.text = shootingAbility.fireBullets.ToString();
			iconImage.color = new Color(unit * shootingAbility.fireBullets
				, unit * shootingAbility.fireBullets
				, unit * shootingAbility.fireBullets);
				break;
		}

		if(attackAbility.selectedElement == attackSelector)
			showOutline = true;
		else 
			showOutline = false;

		Color c = contorno.color;
		if(!showOutline)
		{
			c.a = Mathf.Lerp(0.0f,1.0f,Time.deltaTime *0.5f);
		}
		else
		{
			c.a = Mathf.Lerp(1.0f,0.0f,Time.deltaTime *0.5f);
		}

		contorno.color = c;
		*/

		/*Shooting Ability*/
		switch(attackSelector)
		{
			case Shoot.ShootElement.Lightning:
				healthText.text = shootingAbility.lightningBullets.ToString();
				iconImage.color = new Color(unit * shootingAbility.lightningBullets
					, unit * shootingAbility.lightningBullets
					, unit * shootingAbility.lightningBullets);
	
				break;
		case Shoot.ShootElement.Ice:
				healthText.text = shootingAbility.iceBullets.ToString();
			iconImage.color = new Color(unit * shootingAbility.iceBullets
				, unit * shootingAbility.iceBullets
				, unit * shootingAbility.iceBullets);

				break;
		case Shoot.ShootElement.Fire:
				healthText.text = shootingAbility.fireBullets.ToString();
			iconImage.color = new Color(unit * shootingAbility.fireBullets
				, unit * shootingAbility.fireBullets
				, unit * shootingAbility.fireBullets);
				break;
		case Shoot.ShootElement.Earth:
				healthText.text = shootingAbility.earthBullets.ToString();
			iconImage.color = new Color(unit * shootingAbility.earthBullets
				, unit * shootingAbility.earthBullets
				, unit * shootingAbility.earthBullets);
				break;
		}

		if(shootingAbility.selectedElement == attackSelector)
			showOutline = true;
		else 
			showOutline = false;

		Color c = contorno.color;
		if(!showOutline)
		{
			c.a = Mathf.Lerp(0.0f,1.0f,Time.deltaTime *0.5f);
		}
		else
		{
			c.a = Mathf.Lerp(1.0f,0.0f,Time.deltaTime *0.5f);
		}

		contorno.color = c;
	}

}
