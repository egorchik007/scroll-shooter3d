using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour 
{
	public Transform Target;
	public float Speed = 5.0f;
	public SpaceShip Ship;
	public float CollisionRadius = 0.65f;

	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = Target.position - this.transform.position;
		Vector3 velocity = direction.normalized * Speed * Time.deltaTime * Ship.Speed;

		if (velocity.sqrMagnitude < direction.sqrMagnitude)
		{
			this.transform.position += velocity;
		}
		else 
		{
			this.transform.position = Target.position;
		}

		if (direction.magnitude < 1.0f) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
