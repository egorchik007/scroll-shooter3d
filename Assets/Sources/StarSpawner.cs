using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour 
{
	public GameObject StarPrefab;
	public float StarAppearingFrequency = 1.0f;
	public Vector2 VerticalRange = new Vector2(-5, 7);
	public float StarFlyingDistance = 10f;

	public SpaceShip SpaceShipSpeedProvider;

	private float starTimer;

	void Start () 
	{
		starTimer = StarAppearingFrequency;
	}
	
	void Update () 
	{
		starTimer -= Time.deltaTime;

		if (starTimer <= 0.0f)
		{
			this.GenerateStar();
			starTimer = StarAppearingFrequency;
		}
	}

	public void GenerateStar()
	{
		GameObject newStarObj = (GameObject)Object.Instantiate(StarPrefab);
		Star newStar = newStarObj.GetComponent<Star>();
		newStar.SpeedProvider = SpaceShipSpeedProvider;
		newStar.FlyingDistance = StarFlyingDistance;

		float randomY = Random.Range(VerticalRange.x, VerticalRange.y);

		newStarObj.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
	}
}
