using UnityEngine;
using System.Collections;

public class AimingAsteroid : Asteroid
{
	public override void FixedUpdate()
	{
		direction = (Target.position - transform.position).normalized;
		base.FixedUpdate();
	}
}
