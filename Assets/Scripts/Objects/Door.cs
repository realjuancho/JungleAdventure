using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {


	public ObjectiveChecker objectiveChecker;
	public HotZone hotZone;


	Animator animatorController;
	bool hasKey;
	SoundEffects soundEffects;


	// Use this for initialization
	void Start () {

		animatorController = GetComponent<Animator>();
		hotZone = transform.FindChild("HotZone").gameObject.GetComponent<HotZone>();
		soundEffects = GetComponent<SoundEffects>();
	}
	
	// Update is called once per frame
	void Update () {

		CheckForObjectiveComplete();

		CheckForHotZone();
	}

	void CheckForObjectiveComplete()
	{

		if(objectiveChecker)
		{
			if(objectiveChecker.ObjectiveComplete)
			{
				hasKey = true;
				
			}
		}

	}


	void OpenDoor()
	{
		GetComponent<BoxCollider2D>().enabled = false;

		AudioSource.PlayClipAtPoint(soundEffects.audioClips[0], transform.position);

	}

	void CloseDoor()
	{

		GetComponent<BoxCollider2D>().enabled = true;

		AudioSource.PlayClipAtPoint(soundEffects.audioClips[1], transform.position);
	}


	void CheckForHotZone()
	{
		if(hasKey)
		{
			if(hotZone.playerInHotZone)
			{
				animatorController.SetBool(Hash.Animations.Objects.Door.Open_Bool, true);
			}
			else
			{
				animatorController.SetBool(Hash.Animations.Objects.Door.Open_Bool, false);
			}
		}

	}


}
