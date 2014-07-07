using UnityEngine;
using System.Collections;

public class AsteroidSpawner : ObjectSpawner 
{
	public ScreenBoundary Boundary;

	public override GameObject GenerateObject()
	{
		GameObject newAsteroid = base.GenerateObject();
		Asteroid asteroid = newAsteroid.GetComponent<Asteroid>();
		asteroid.Target = SpaceShip.transform;
		asteroid.Ship = SpaceShip;
		asteroid.Boundary = Boundary;

		return newAsteroid;
	}
}
