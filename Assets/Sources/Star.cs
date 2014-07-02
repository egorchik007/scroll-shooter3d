using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour 
{	
	public float StarSpeed = 20f;

	[System.NonSerialized]
	public GameController GameController;

	// Update is called once per frame
	void Update () 
	{
		Vector3 position = transform.position;
		position.x -= StarSpeed * Time.deltaTime * GameController.SpaceShipSpeed;
		transform.position = position;

		if (transform.position.x < -20.0f)
		{
			Object.Destroy(gameObject);
		}
	}
}
