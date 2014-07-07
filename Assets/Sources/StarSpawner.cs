using UnityEngine;
using System.Collections;

public class StarSpawner : ObjectSpawner 
{
	public override GameObject GenerateObject ()
	{
		GameObject newStarObj = base.GenerateObject ();
		Star newStar = newStarObj.GetComponent<Star>();
		newStar.SpeedProvider = SpaceShip;
		newStar.FlyingDistance = FlyingDistance;

		return newStarObj;
	}
}
