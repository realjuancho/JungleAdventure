using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour {


	SaveGameManager saveGameMgr;
	// Use this for initialization

	public bool[] unlockedLevels;
	public int[] earnedStars;

	void Start () 
	{


		saveGameMgr = GameObject.FindObjectOfType<SaveGameManager>();

		if(SceneManager.GetActiveScene().name == "levelSelect")
		{
			Debug.Log("LevelSelect" + saveGameMgr.GetUnlockedLevels());

			unlockedLevels = saveGameMgr.GetUnlockedLevels();


			int i = 1;
			foreach(bool levelUnlock in unlockedLevels)
			{
				Image lockedImage = GameObject.Find("locked"+i).GetComponent<Image>();
				Button panelButton = GameObject.Find("btnLoad"+i).GetComponent<Button>();


				if(i == 1){
					lockedImage.enabled = false;

					}
				else 
				{
					 lockedImage.enabled = !levelUnlock;
					 panelButton.enabled = levelUnlock;
				}
				i++;
			}


			earnedStars = saveGameMgr.GetStarsEarned();

			Sprite noDiamonds =  Resources.Load<Sprite>(Hash.Sprites.DiamondsEarnedSprites.noDiamonds);
			Sprite _1Diamond = Resources.Load<Sprite>(Hash.Sprites.DiamondsEarnedSprites._1Diamond);
			Sprite _2Diamonds = Resources.Load<Sprite>(Hash.Sprites.DiamondsEarnedSprites._2Diamonds);
			Sprite _3Diamonds = Resources.Load<Sprite>(Hash.Sprites.DiamondsEarnedSprites._3Diamonds);

			i = 1;


			foreach(int star in earnedStars)
			{
				Image starsEarnedImage = GameObject.Find("stars"+i).GetComponent<Image>();


				switch(star)
				{
					case 0:
						starsEarnedImage.sprite = noDiamonds;
						break;
				case 1:
						starsEarnedImage.sprite = _1Diamond;
						break;
				case 2:
						starsEarnedImage.sprite = _2Diamonds;
						break;
				case 3:
						starsEarnedImage.sprite = _3Diamonds;
						break;
				default:
						starsEarnedImage.sprite = noDiamonds;
						break;
				}

					
				
				i++;
			}


		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void LoadLevel(string levelName)
	{
		


		Debug.Log("scene: " + levelName);

		SceneManager.LoadScene(levelName, LoadSceneMode.Single);
	}



}
