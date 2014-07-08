using UnityEngine;
using System.Collections;

public class NPCSpaceShip : SpaceShip
{
	public override void Update()
	{
		ScanEnemies();

		if (ShouldShootGun())
		{
			ShootGun();
		}
		else if (Mathf.Abs(Velocity.y) > 10f)
		{
			Deccelerate();
		}
		else
		{
			if (DistanceToNearestAsteroid() > 15f)
			{
				if (NearestAsteroidY() > transform.position.y)
				{
					AccelerateUp();
				}
				else if (NearestAsteroidY() < transform.position.y)
				{
					AccelerateDown();
				}
				else
				{
					Deccelerate();
				}
			}
			else
			{
				if (AsteroidTargetYWeight() < 0)
				{
					AccelerateUp();
				}
				else
				{
					AccelerateDown();
				}
			}
		}
	}

	#region] AI blocks
	private Asteroid[] visibleEnemies = new Asteroid[0];

	#region Decisions
	private bool ShouldShootGun()
	{
		return Physics.Raycast(transform.position, Vector3.right);
	}

	private int AsteroidTargetYWeight()
	{
		int weight = 0;
		foreach (var asteroid in visibleEnemies)
		{
			float dx = transform.position.x - asteroid.transform.position.x;
			float resY = asteroid.transform.position.y + asteroid.Direction.y * dx / asteroid.Direction.x;
			weight += resY > transform.position.y ? 1 : -1;
		}
		return weight;
	}

	private float DistanceToNearestAsteroid()
	{
		float dist = float.PositiveInfinity;
		foreach (var asteroid in visibleEnemies)
		{
			float dx = transform.position.x - asteroid.transform.position.x;
			if (dx < dist)
				dist = dx;
		}
		return dist;
	}

	private float NearestAsteroidY()
	{
		float y = transform.position.y;
		float dist = float.PositiveInfinity;
		foreach (var asteroid in visibleEnemies)
		{
			float dx = transform.position.x - asteroid.transform.position.x;
			if (dx < dist)
			{
				dist = dx;
				y = asteroid.transform.position.y;
			}
		}
		return y;
	}
	
	void OnDrawGizmos()
	{
		foreach (var asteroid in visibleEnemies)
		{
			if (asteroid)
			{
				float dx = transform.position.x - asteroid.transform.position.x;
				float resY = asteroid.transform.position.y + asteroid.Direction.y * dx / asteroid.Direction.x;
				Gizmos.DrawLine(asteroid.transform.position, new Vector3(transform.position.x, resY, 0));
			}
		}
	}
	
	private bool ShouldDeccelerate()
	{
		return false;
	}
	#endregion

	#region Actions
	private void ScanEnemies()
	{
		visibleEnemies = FindObjectsOfType<Asteroid>();
	}

	private void ShootGun()
	{
		gun[0].Shoot(this);
	}
	
	private void AccelerateUp()
	{
		acceleration.y = 20f * Time.deltaTime;
	}
	
	private void AccelerateDown()
	{
		acceleration.y = -20f * Time.deltaTime;
	}
	
	private void Deccelerate()
	{
		acceleration.y = -Velocity.y * Time.deltaTime;
	}
	#endregion
	#endregion
}
