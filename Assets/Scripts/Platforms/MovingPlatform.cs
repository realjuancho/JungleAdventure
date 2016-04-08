using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingPlatform : MonoBehaviour {

	
	public PlatformActivator activator;
	public bool isPlatformEnabled;

	public float speed = 3.0f;
	public PlatformWaypoint[] myWayPoints_array;
	List<PlatformWaypoint> myWayPoints;
	public PlatformTransform platformTransform;
	public bool returnToFirstWhenFinished = true;




	// Use this for initialization
	void Awake () {

		myWayPoints_array = GetComponentsInChildren<PlatformWaypoint>();
		myWayPoints = new List<PlatformWaypoint>(myWayPoints_array);
		myWayPoints.Sort((x,y) =>
   			 x.PlatformOrder.CompareTo(y.PlatformOrder));

		platformTransform = GetComponentInChildren<PlatformTransform>();



	}
	
	// Update is called once per frame

	bool doMovePlatform;

	void Update () {

		

		CheckPlatformEnabled();
	}




	void CheckPlatformEnabled()
	{

		if(activator)
		{
			isPlatformEnabled = activator.activated;
		}
		else
		{
			isPlatformEnabled = true;
		}

		if(isPlatformEnabled)
		{
			MoveBetweenWayPoints();
		}

		if(doMovePlatform)
		{
			MovePlatform();
		}
		

	}

	PlatformWaypoint currentWayPoint;
	int currentWayPointID;
	float timeInCurrentWaypoint;
	bool arrivedToPosition;

	bool goingBackwards;

	void MoveBetweenWayPoints()
	{

		if(currentWayPoint)
		{
			if(arrivedToPosition) timeInCurrentWaypoint += Time.deltaTime;
			if(timeInCurrentWaypoint >= currentWayPoint.timeToReleasePlatform)
			{
				if(!goingBackwards)
				{
					if(currentWayPoint != myWayPoints[myWayPoints.Count -1] )
					{
						currentWayPointID++;
						currentWayPoint = myWayPoints[currentWayPointID];
					}
					else
					{
						if(returnToFirstWhenFinished)
						{
							currentWayPointID = 0;
							currentWayPoint = myWayPoints[currentWayPointID];
						}
						else
						{
							currentWayPointID--;
							currentWayPoint = myWayPoints[currentWayPointID];
							goingBackwards = true;
						}
					}
				}
				else
				{
					if(currentWayPoint != myWayPoints[0] )
					{
						currentWayPointID--;
						currentWayPoint = myWayPoints[currentWayPointID];
					}
					else
					{	
						currentWayPointID++;
						currentWayPoint = myWayPoints[currentWayPointID];
						goingBackwards = false;
					}
				}

				doMovePlatform = true;
				arrivedToPosition = !doMovePlatform;
 				timeInCurrentWaypoint = 0.0f;
			}
		}
		else

		{	
			currentWayPointID = 0;
			currentWayPoint = myWayPoints[currentWayPointID];

			doMovePlatform=true;
			arrivedToPosition=!doMovePlatform;
		}
	}

	private Vector2 _currentVelocity;

	void MovePlatform()
	{
		
		platformTransform.transform.position =  Vector2.SmoothDamp(platformTransform.transform.position, currentWayPoint.transform.position, ref _currentVelocity , speed * Time.deltaTime);

		Vector3 distancia = currentWayPoint.transform.position - platformTransform.transform.position;

		if(distancia.magnitude < 0.01f)
		{
			platformTransform.transform.position = currentWayPoint.transform.position;
			doMovePlatform = false;
			arrivedToPosition = !doMovePlatform;
		}
	}
}
