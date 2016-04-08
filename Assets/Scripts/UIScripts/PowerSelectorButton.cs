using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerSelectorButton : MonoBehaviour {


	public Attack.AttackElement attackSelector;
	AttackAbility attackAbility;
	Text healthText;

	Image iconImage;
	Image contorno;

	bool showOutline;

	void Start()
	{
		attackAbility = GameObject.FindObjectOfType<AttackAbility>();

		iconImage = GetComponent<Image>();
		contorno = gameObject.transform.FindChild("Contorno").GetComponent<Image>();

		showOutline = false;

		healthText = GetComponentInChildren<Text>();
	}


	void Update()
	{
		float unit = 155.0f / 1000.0f;

		switch(attackSelector)
		{
			case Attack.AttackElement.Lightning:
				healthText.text = attackAbility.lightningAttackHealth.ToString();
				iconImage.color = new Color(unit * attackAbility.lightningAttackHealth
					, unit * attackAbility.lightningAttackHealth
					, unit * attackAbility.lightningAttackHealth);
	
				break;
			case Attack.AttackElement.Ice:
				healthText.text = attackAbility.iceAttackHealth.ToString();
			iconImage.color = new Color(unit * attackAbility.iceAttackHealth
				, unit * attackAbility.iceAttackHealth
				, unit * attackAbility.iceAttackHealth);

				break;
			case Attack.AttackElement.Fire:
				healthText.text = attackAbility.fireAttackHealth.ToString();
			iconImage.color = new Color(unit * attackAbility.fireAttackHealth
				, unit * attackAbility.fireAttackHealth
				, unit * attackAbility.fireAttackHealth);
				break;
			case Attack.AttackElement.Earth:
				healthText.text = attackAbility.earthAttackHealth.ToString();
			iconImage.color = new Color(unit * attackAbility.earthAttackHealth
				, unit * attackAbility.earthAttackHealth
				, unit * attackAbility.earthAttackHealth);
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
	}

}
