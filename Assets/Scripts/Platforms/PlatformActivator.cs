using UnityEngine;
using System.Collections;

public class PlatformActivator : MonoBehaviour {


	public bool activated;

	DetectionRay[] detection; 

	Animator animator;

	// Use this for initialization
	void Awake () {
		detection = GetComponentsInChildren<DetectionRay>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {




		foreach(DetectionRay d in detection )
		{
			if(d.detected)
				{
				activated = true;
				break;
				}
			else
				activated = false;
			
		}


		animator.SetBool(Hash.Animations.Platforms.PlatformActivator_Activate_Bool, activated);
	}
}
