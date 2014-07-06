using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class Missile : Star
{
	private float radius = 0f;

	public void Start()
	{
		radius = collider.bounds.size.x;
	}

	public override void Update()
	{
		base.Update();

		foreach (var collision in Physics.OverlapSphere(transform.position, radius))
		{
			if (collision.CompareTag("Enemy"))
			{
				Object.Destroy(this.gameObject);
				Object.Destroy(collision.transform.gameObject);
				GameController.Instance.Score += 10;
			}
		}
	}
}
