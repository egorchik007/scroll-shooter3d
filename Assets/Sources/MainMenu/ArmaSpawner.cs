using UnityEngine;
using System.Collections;

public class ArmaSpawner : MonoBehaviour
{
	public GameObject ArmaPrefab;
	public float AppearingFrequency = 1.0f;	
	public MenuShip Ship;
	public GameObject Dir;
	
	private float normalizedStarTimer;
	private bool access=false;
	
	void Start()
	{
		normalizedStarTimer = 0.0f;
	}
	
	void Update()
	{
		access = Ship.move;
		normalizedStarTimer -= Time.deltaTime * AppearingFrequency;
		
		if (normalizedStarTimer <= 0.0f && access)
		{
			this.GenerateArma();
			normalizedStarTimer = 1.0f;
		}
	}
	
	public void GenerateArma()
	{
		GameObject newArma = (GameObject)Object.Instantiate(ArmaPrefab);
		MenuArma Arma = newArma.GetComponent<MenuArma>();
		Arma.Ship = Ship;
		Arma.Dir = Dir;
		
		float randomY = Random.Range(0.0f, 1.0f);
		
		newArma.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
		Arma.Ship = Ship;
	}
}