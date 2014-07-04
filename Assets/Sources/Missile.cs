using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Missile : Star
{
	List<GameObject> enemies;
	public void Start()
	{

	}

	public override void Update()
	{
		base.Update();

		enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

		foreach (GameObject enemy in enemies)
		{
			if (Vector3.SqrMagnitude(transform.position - enemy.transform.position) < 0.65f)
			{
				enemies.Remove(enemy);
				Object.Destroy(enemy);
				Object.Destroy(this.gameObject);

				GameController.Instance.Score += 10;

				break;
			}
		}
	}
}
