using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Missile : Star
{
		List<GameObject> enemies;
		public Transform explosion;
		public bool homing = false;
		public float homingSpeed = 10f;
		public float homingDistance = 70f;
		public GameObject homingEffect;
		GameObject currentenemy;
		GameObject lastenemy;

		public void Start ()
		{
		}

		public override void Update ()
		{
				base.Update ();

				enemies = new List<GameObject> (GameObject.FindGameObjectsWithTag ("Enemy"));

				foreach (GameObject enemy in enemies) {
						#region Homing
						if (homing && (currentenemy == null || currentenemy == enemy)) {
								float dist = Vector3.SqrMagnitude (transform.position - enemy.transform.position);
								if (dist < homingDistance) {
										currentenemy = enemy;
										transform.position -= new Vector3 (0, (transform.position - enemy.transform.position).normalized.y * Time.deltaTime * homingSpeed, 0);

										if (dist > 5f)
												transform.rotation = Quaternion.Euler (0, 0, 270 - (transform.position - enemy.transform.position).y / (transform.position - enemy.transform.position).sqrMagnitude * homingSpeed * 20);

										if (homingEffect != null && currentenemy != lastenemy) {
												var tmp = (GameObject)Instantiate (homingEffect, enemy.transform.position, Quaternion.identity);
												tmp.transform.parent = enemy.transform;
												lastenemy = enemy;
										}
								}
						}

						#endregion
			if (enemy != null && enemy.GetComponent<Asteroid> ()!=null)

						if (Vector3.SqrMagnitude (transform.position - enemy.transform.position) < enemy.GetComponent<Asteroid> ().CollisionRadius) {
								enemies.Remove (enemy);
								Object.Destroy (enemy);
								Object.Destroy (this.gameObject);

								Transform ex = (Transform)Instantiate (explosion, enemy.transform.position, Quaternion.identity);
								GameController.Instance.Score += 10;
								currentenemy = null;
								break;
						}
				}
		}
}
