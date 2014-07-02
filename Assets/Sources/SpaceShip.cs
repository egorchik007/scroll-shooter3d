using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour, ISpeedProvider
{
	#region ISpeedProvider implementation

	public float Speed
	{
		get { return Velocity.x; }
	}

	#endregion

	public Vector2 Velocity = Vector2.right;
	private Vector2 acceleration = Vector2.zero;

	void Start ()
	{
	}
	
	void Update ()
	{
		#region Input processing
		if (Input.GetKey(KeyCode.UpArrow))
		{
			acceleration.y += 1f * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			acceleration.y -= 1f * Time.deltaTime;
		}
		else
		{
			acceleration.y = -Velocity.y * Time.deltaTime;
		}
		#endregion

		Velocity += acceleration;
		transform.position += new Vector3(0f, Time.deltaTime * Velocity.y, 0f);
		const float scaleFactor = 30f;
		transform.localScale = new Vector3(1f, scaleFactor / (scaleFactor + Mathf.Abs (Velocity.y)), 1f);
	}
}
