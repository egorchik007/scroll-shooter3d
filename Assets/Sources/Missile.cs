using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class Missile : Star
{
	private float radius = 0f;

	public void Start()
	{
		radius = collider.bounds.size.x / 2f;
	}

	public override void Update()
	{
		base.Update();

		foreach (var hit in Physics.SphereCastAll(transform.position, radius, Vector3.right, distance))
		{
			if (hit.transform.CompareTag("Enemy"))
			{
				Object.Destroy(this.gameObject);
				Object.Destroy(hit.transform.gameObject);
				GameController.Instance.Score += 10;
			}
		}
	}
}
