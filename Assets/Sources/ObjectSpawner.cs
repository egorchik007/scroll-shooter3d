using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
	public GameObject ObjectPrefab;
	public float AppearingFrequency = 1.0f;
	public Vector2 VerticalRange = new Vector2(-5, 7);
	public float FlyingDistance = 10f;
	
	public SpaceShip SpaceShip;

	private float normalizedStarTimer;

	void Start() 
	{
		normalizedStarTimer = 0.0f;
	}
	
	void Update() 
	{
		normalizedStarTimer -= Time.deltaTime * AppearingFrequency * SpaceShip.Speed;
		
		if (normalizedStarTimer <= 0.0f)
		{
			this.GenerateObject();
			normalizedStarTimer = 1.0f;
		}
	}

	public virtual GameObject GenerateObject()
	{
		GameObject newAsteroid = (GameObject)Object.Instantiate(ObjectPrefab);
		float randomY = Random.Range(VerticalRange.x, VerticalRange.y);
		newAsteroid.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);

		return newAsteroid;
	}
}
