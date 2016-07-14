using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	[SerializeField] double timeElapsed;
 	[SerializeField] int money;
 	[SerializeField] int explorersUsed;

	public Player player;
	public ShootingAbility shootingAbility;
	public CheckPoint currentCheckPoint;

	Text txtMoney;
	Text txtExplorers;

	Text txtTimeComplete;
	Text txtMoneyFound;
	Text txtExplorersUsed;

	Text lblObjective;
	Image imageDiamonds;

	public bool isPaused;
	public bool isEndLevel = false;


	Canvas endLevelCanvas;
	Canvas touchCanvas;

	void Awake()
	{
		player = GameObject.FindObjectOfType<Player>();
		shootingAbility = player.GetComponentInChildren<ShootingAbility>();

		txtMoney = GameObject.Find("txtMoney").GetComponent<Text>();
		txtExplorers = GameObject.Find("txtExplorers").GetComponent<Text>();


		txtMoneyFound = GameObject.Find("txtMoneyFound").GetComponent<Text>();
		txtTimeComplete = GameObject.Find("txtTimeComplete").GetComponent<Text>();
		txtExplorersUsed = GameObject.Find("txtExplorersUsed").GetComponent<Text>();

		touchCanvas = GameObject.Find("TouchCanvas").GetComponent<Canvas>();
		endLevelCanvas = GameObject.Find("EndLevelCanvas").GetComponent<Canvas>();

		lblObjective = GameObject.Find("lblObjectives").GetComponent<Text>();

		imageDiamonds = GameObject.Find("imgDiamonds").GetComponent<Image>();
	}

	void Update()
	{
		if(player.isDead)
		{
			player.ReSpawn(GetCurrentCheckpoint().transform.position);
		}


		if(!isEndLevel)
		{
			touchCanvas.enabled = true;
			endLevelCanvas.enabled = false;	
		}



		txtMoney.text = money.ToString();
		txtExplorers.text = explorersUsed.ToString();

		txtMoneyFound.text = money.ToString();
		txtExplorersUsed.text = explorersUsed.ToString();

		if(!isPaused && !isEndLevel)
		{
			timeElapsed += Time.deltaTime;
			TimeSpan ts = TimeSpan.FromSeconds(timeElapsed);
			int lenght = ts.ToString().Length;
			string timeSpan_str = ts.ToString().Substring(0, lenght-5);
			txtTimeComplete.text = timeSpan_str;	
		}

		bulletsLeft = shootingAbility.bulletsLeft;

	}

	public void LastCheckPoint(CheckPoint checkPointPassed)
	{
		currentCheckPoint = checkPointPassed;
	}

	public CheckPoint GetCurrentCheckpoint()
	{

		if(!currentCheckPoint)
			currentCheckPoint = GameObject.FindObjectOfType<CheckPoint>();
		return currentCheckPoint;
		
	}

	public void RetryLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		
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

	int bulletsLeft;

	public static int GetBulletsLeft()
	{
		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		return gm.bulletsLeft;

	}


	public static void ReachEndLevel(int levelFinished, int UnlockedDiamonds)
	{

		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		gm.isEndLevel = true;

		gm.imageDiamonds.sprite = gm.GetDiamondsSprite(UnlockedDiamonds);

		gm.endLevelCanvas.enabled = true;
		gm.touchCanvas.enabled = false;
		gm.player.CanControl(false);
		gm.player.Stop();


		SaveGameManager sgm = GameObject.FindObjectOfType<SaveGameManager>();
		sgm.UnlockLevel(levelFinished);
		sgm.SetDiamondsEarned(levelFinished, UnlockedDiamonds);

	}

	public static void SetObjective(string ObjectiveText)
	{

		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		gm.lblObjective.text = ObjectiveText;

	}

	public static void RemoveObjective()
	{

		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		gm.lblObjective.text = "";

	}

	public static int getMoney()
	{

		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		return gm.money;

	}

	public static int getExplorersUsed()
	{

		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		return gm.explorersUsed;

	}

	public static double getTimeUsed()
	{

		GameManager gm = (GameManager)GameObject.FindObjectOfType<GameManager>();
		return gm.timeElapsed;

	}



	public void SetPause()
	{
		isPaused= !isPaused;

		if(isPaused)
		{	
			Time.timeScale = 0.000001f;
		}
		else{
			Time.timeScale = 1;
		}

	}


	public Sprite GetDiamondsSprite(int UnlockedDiamonds)
	{
		Sprite diamonds;

		switch(UnlockedDiamonds)
		{
			case 1:
				diamonds = Resources.Load<Sprite>(Hash.Sprites.DiamondsEarnedSprites._1Diamond);
			break;

			case 2:

			diamonds = Resources.Load<Sprite>(Hash.Sprites.DiamondsEarnedSprites._2Diamonds);
				
			break;

			case 3:
			diamonds = Resources.Load<Sprite>(Hash.Sprites.DiamondsEarnedSprites._3Diamonds);
			break;

			default:
			diamonds = Resources.Load<Sprite>(Hash.Sprites.DiamondsEarnedSprites.noDiamonds);
			break;
		}

		return diamonds;
		
	}


}
