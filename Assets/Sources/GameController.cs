using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject StarPrefab;
	public float StarAppearingFrequency = 1.0f;
	public float SpaceShipSpeed = 1.0f;

	private float StarTimer;

	// Use this for initialization
	void Start () 
	{
		StarTimer = StarAppearingFrequency;
	}
	
	// Update is called once per frame
	void Update () 
	{
		StarTimer -= Time.deltaTime;

		if (StarTimer <= 0.0f)
		{
			this.GenerateStar();
			StarTimer = StarAppearingFrequency;
		}
	}

	public void GenerateStar()
	{
		GameObject newStar = (GameObject)Object.Instantiate(StarPrefab);
		newStar.GetComponent<Star>().GameController = this;

		float randomY = Random.Range(-5.0f, 7.0f);

		Vector3 position = newStar.transform.position;
		position.y = randomY;
		newStar.transform.position = position;
	}
}
