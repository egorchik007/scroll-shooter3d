using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Missile : Star
{
	List<GameObject> enemies;
	public void Start()
	{
		enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
	}

	public override void Update()
	{
		base.Update ();

		foreach (GameObject enemy in enemies)
		{
			if (Vector3.SqrMagnitude(transform.position - enemy.transform.position) < 1.5f)
			{
				enemies.Remove(enemy);
				Object.Destroy(enemy);
				Object.Destroy(this.gameObject);
				break;
			}
		}
	}
}
