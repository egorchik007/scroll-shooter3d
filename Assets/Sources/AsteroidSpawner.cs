using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour 
{
	public GameObject AsteroidPrefab;
	public float AppearingFrequency = 1.0f;
	public Vector2 VerticalRange = new Vector2(-5, 7);
	public float FlyingDistance = 10f;
	
	public SpaceShip SpaceShip;
	
	private float normalizedStarTimer;
	
	void Start () 
	{
		normalizedStarTimer = 0.0f;
	}
	
	void Update () 
	{
		normalizedStarTimer -= Time.deltaTime * AppearingFrequency * SpaceShip.Speed;
		
		if (normalizedStarTimer <= 0.0f)
		{
			this.GenerateAstoroid();
			normalizedStarTimer = 1.0f;
		}
	}
	
	public void GenerateAstoroid()
	{
		GameObject newAsteroid = (GameObject)Object.Instantiate(AsteroidPrefab);
		Asteroid asteroid = newAsteroid.GetComponent<Asteroid>();
		asteroid.Target = SpaceShip.transform;
		asteroid.Ship = SpaceShip;

		float randomY = Random.Range(VerticalRange.x, VerticalRange.y);
		
		newAsteroid.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
	}
}
