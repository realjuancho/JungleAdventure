using System;

[Serializable]
public class GameDetails
{
    public int fireAmmoCount;
    public int iceAmmoCount;
    public int lightningAmmoCount;
    public int earthAmmoCount;

    public int lastLevelPlayed;

    public bool[] levelsUnlocked;
    public int[] starsEarned;

    
    public GameDetails()
    {
        
    }

    public GameDetails(bool newGame)
    {

    	if(newGame)
    	{
    		fireAmmoCount = 10;
    		iceAmmoCount = 10;
    		lightningAmmoCount = 10;
    		earthAmmoCount = 10;

    	 	levelsUnlocked = new bool[] { 
						//World1
    	 				true, false, false, false, false,
    	 				//World2
    	 				false, false, false, false, false,
						//World3
    	 				false, false, false, false, false,
						//World4
    	 				false, false, false, false, false,
						//World5
    	 				false, false, false, false, false

    	 
    	 	};

			
    	 	starsEarned = new int[]{
    	 	//World1
			0,0,0,0,0,
			//World2
			0,0,0,0,0,
			//World3
			0,0,0,0,0,
			//World4
			0,0,0,0,0,
			//World5
			0,0,0,0,0,
    	 	};

			
    	}

    }


}

[Serializable]
public class GameSettings
{
    public float effectsVolume;
    public float musicVolume;
   
    
    public GameSettings()
    {
        
    }

    public GameSettings(bool newGame)
    {

    	if(newGame)
    	{
    		effectsVolume = 0.3f;
    		musicVolume = 1.0f;

    	
    	}


    }


}
