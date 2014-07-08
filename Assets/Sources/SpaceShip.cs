using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Gun))]
public abstract class SpaceShip : MonoBehaviour, ISpeedProvider
{
	#region ISpeedProvider implementation

	public float Speed
	{
		get { return Velocity.x; }
	}

	#endregion

	public Vector2 Velocity = Vector2.right;
	public Vector2 SpeedXLimits = new Vector2(0f, 10f);
	protected Vector2 acceleration = Vector2.zero;

	public float RollScaleFactor = 2f;

	public ScreenBoundary Boundary;
	protected Gun[] gun;

	void Start ()
	{
		gun = GetComponents<Gun>();
		if (gun.Length < 2)
			Debug.LogError("This spaceship should have at least 2 guns", this);
	}

	public abstract void Update();

	protected void FixedUpdate()
	{
		Velocity += acceleration;
		Velocity.x = Mathf.Clamp(Velocity.x, 0.1f, 10f);
		Move(0f, Time.fixedDeltaTime * Velocity.y);
		transform.localRotation = Quaternion.Euler(Velocity.y * RollScaleFactor, 0f, 0f);
	}

	protected void Move(float x, float y)
	{
		Vector3 newPosition = transform.position + new Vector3(x, y, 0f);
		if (Boundary.Boundary.Contains(newPosition))
		{
			transform.position = newPosition;
		}
		else if (0 != y)
		{
			Velocity.y = -Velocity.y;
		}
	}
}
