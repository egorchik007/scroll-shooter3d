using UnityEngine;
using System.Collections;

public class DroidSpawner : MonoBehaviour 
{
	public GameObject DroidPrefab;
	public float AppearingFrequency = 1.0f;
	public Vector2 VerticalRange = new Vector2(-5, 7);
	public float FlyingDistance = 10f;
	public ScreenBoundary Boundary;
	
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
			this.GenerateDroid();
			normalizedStarTimer = 1.0f;
		}
	}
	
	public void GenerateDroid()
	{
		GameObject newDroid = (GameObject)Object.Instantiate(DroidPrefab);
		Droid droid = newDroid.GetComponent<Droid>();		
		droid.Ship = SpaceShip;
		droid.explosion = SpaceShip.transform;
		droid.Boundary = Boundary;
		
		float randomY = Random.Range(VerticalRange.x, VerticalRange.y);
		
		newDroid.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
	}
}
