using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization

	SaveGameManager sgm = new SaveGameManager();
		

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}


	public void LoadMenuScene()
	{
		SceneManager.LoadScene("levelSelect");
	}
}
