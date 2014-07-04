using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Gun))]
public class SpaceShip : MonoBehaviour, ISpeedProvider
{
	#region ISpeedProvider implementation

	public float Speed
	{
		get { return Velocity.x; }
	}

	#endregion

	public Vector2 Velocity = Vector2.right;
	public Vector2 SpeedXLimits = new Vector2(0f, 10f);
	private Vector2 acceleration = Vector2.zero;

	public float RollScaleFactor = 2f;

	public ScreenBoundary Boundary;
	private Gun[] gun;

	void Start ()
	{
		gun = GetComponents<Gun>();
		if (gun.Length < 2)
			Debug.LogError("This spaceship should have at least 2 guns", this);
	}
	
	void Update ()
	{
		#region Input processing
		if (Input.GetKey(KeyCode.UpArrow))
		{
			acceleration.y = 20f * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			acceleration.y = -20f * Time.deltaTime;
		}
		else
		{
			acceleration.y = -Velocity.y * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			Velocity.x = Mathf.Clamp(Velocity.x + 1f * Time.deltaTime, SpeedXLimits.x, SpeedXLimits.y);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			Velocity.x = Mathf.Clamp(Velocity.x - 1f * Time.deltaTime, SpeedXLimits.x, SpeedXLimits.y);
		}

		if (Input.GetKey(KeyCode.Space))
		{
			gun[0].Shoot(this);
		}
		if (Input.GetKey(KeyCode.A))
		{
			gun[1].Shoot(this);
		}
		#endregion

		Velocity += acceleration;
		Move(0f, Time.deltaTime * Velocity.y);
		transform.localRotation = Quaternion.Euler(Velocity.y * RollScaleFactor, 0f, 0f);
	}

	private void Move(float x, float y)
	{
		Vector3 newPos = transform.position + new Vector3(x, y, 0f);
		if (Boundary.Boundary.Contains(newPos))
		{
			transform.position = newPos;
		}
		else
		{
			Velocity.y = -Velocity.normalized.y*10;
		}
	}

}
