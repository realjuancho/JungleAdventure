using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveGameManager : MonoBehaviour {

	public GameDetails gd;
	public GameSettings gs;


	GameManager gm;

	void Awake()
	{
		SingletonPattern();

		gd = DataAccess.Load();

		if(gd == null)
		{
			gd = new GameDetails(true);
			DataAccess.Save(gd);
		}

		gs = DataAccess.LoadSettings();

		if(gs == null)
		{
			gs = new GameSettings(true);
			DataAccess.Save(gs);
		}

		gm = GameObject.FindObjectOfType<GameManager>();

		if(gm)
			gameObject.transform.SetParent(gm.transform);

	}

	public static SaveGameManager instance = null ;

	void SingletonPattern()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(this);
	}

	void Update()
	{
		
	}


	public void SaveData()
	{
		DataAccess.Save(gd);

	}

	public void LoadData()
	{

		gd = DataAccess.Load();

	}

	public void SaveSettings()
	{
		DataAccess.Save(gs);
	}

	public void LoadSettings()
	{
		gs = DataAccess.LoadSettings();
	}
	
	public void DeleteData()
	{
		DataAccess.Delete();

		gd = new GameDetails(true);
	}

	public void UnlockLevel(int level)
	{
		gd.levelsUnlocked[level -1] = true;
		DataAccess.Save(gd);
	}

	public void SetDiamondsEarned(int level, int DiamondsEarned)
	{
		gd.levelsUnlocked[level -1] = true;

		if(DiamondsEarned > gd.starsEarned[level -1])
			gd.starsEarned[level -1] = DiamondsEarned;

		DataAccess.Save(gd);
	}


    public bool[] GetUnlockedLevels()
    {
   		return gd.levelsUnlocked; 
    }

    public int[] GetStarsEarned()
    {
    	return gd.starsEarned;
    }

}
