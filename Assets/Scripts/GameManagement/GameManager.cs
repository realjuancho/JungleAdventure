using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {


	
 

 	[SerializeField] int money;
 	[SerializeField] int explorersUsed;

	public Player player;
	public CheckPoint currentCheckPoint;

	Text txtMoney;
	Text txtExplorers;

	void Awake()
	{
		player = GameObject.FindObjectOfType<Player>();

		txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
		txtExplorers = GameObject.Find("txtExplorers").GetComponent<Text>();
	}

	void Update()
	{
		if(player.isDead)
		{
			player.ReSpawn(GetCurrentCheckpoint().transform.position);
		}

		txtMoney.text = money.ToString();
		txtExplorers.text = explorersUsed.ToString();
	}

	public void LastCheckPoint(CheckPoint checkPointPassed)
	{
		currentCheckPoint = checkPointPassed;
	}

	public CheckPoint GetCurrentCheckpoint()
	{
		return currentCheckPoint;
		
	}

 	public static void AddMoney()
	{

		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		gm.money++;
	}

	public static void AddExplorerCount()
	{

		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		gm.explorersUsed++;
	}

}
