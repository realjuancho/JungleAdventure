using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SaveGameManager : MonoBehaviour {


	public static SaveGameManager instance = null ;
	public GameDetails gd;

	void Awake()
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


	void Start()
	{

		gd = DataAccess.Load();

		if(gd == null)
		{
			gd = new GameDetails(true);
			DataAccess.Save(gd);
		}

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
