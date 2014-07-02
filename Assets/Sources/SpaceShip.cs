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

	public float RollScaleFactor = 2f;

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
		transform.localRotation = Quaternion.Euler(Velocity.y * RollScaleFactor, 0f, 0f);
	}
}
