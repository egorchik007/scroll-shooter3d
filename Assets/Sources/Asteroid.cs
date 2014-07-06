using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Asteroid : MonoBehaviour 
{
	public Transform Target;
	public float Speed = 5.0f;
	public SpaceShip Ship;
	public ScreenBoundary Boundary;

	private float radius = 0f;

	void Start()
	{
		radius = collider.bounds.size.x;
	}

	void Update()
	{
		if (transform.position.x < Boundary.Boundary.min.x)
		{
			Object.Destroy(gameObject);
		}
	}

	void FixedUpdate()
	{
		Vector3 direction = (Target.position - transform.position).normalized;
		Vector3 velocity = new Vector3(-Speed * Time.fixedDeltaTime * Ship.Speed, direction.y * Speed * Time.fixedDeltaTime);
		
		transform.position += velocity;

		foreach (var collision in Physics.OverlapSphere(transform.position, radius))
		{
			if (collision.CompareTag("Player"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
