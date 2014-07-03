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

	public ScreenBounding FieldBounds;

	void Start ()
	{
	}
	
	void Update ()
	{
		#region Input processing
		if (Input.GetKey(KeyCode.UpArrow))
		{
			acceleration.y = 5f * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			acceleration.y = -5f * Time.deltaTime;
		}
		else
		{
			acceleration.y = -Velocity.y * Time.deltaTime;
		}

		if (Input.GetKey(KeyCode.RightArrow))
		{
			Move(2f * Time.deltaTime, 0f);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			Move(-2f * Time.deltaTime, 0f);
		}

		if (Input.GetKey(KeyCode.Space))
		{
			Shoot();
		}
		#endregion

		Velocity += acceleration;
		Velocity.x = Mathf.Clamp(Velocity.x, 0.1f, 10f);
		Move(0f, Time.deltaTime * Velocity.y);
		transform.localRotation = Quaternion.Euler(Velocity.y * RollScaleFactor, 0f, 0f);
	}

	private void Move(float x, float y)
	{
		Vector3 newPosition = transform.position + new Vector3(x, y, 0f);
		if (FieldBounds.Bounds.Contains(newPosition))
		{
			transform.position = newPosition;
		}
		else if (0 != y)
		{
			Velocity.y = -Velocity.y;
		}
	}

	internal class BulletSpeedProvider : ISpeedProvider
	{
		private float speed;
		ISpeedProvider worldSpeedProvider;
		public BulletSpeedProvider(float speed, ISpeedProvider worldSpeed)
		{
			this.speed = speed;
			this.worldSpeedProvider = worldSpeed;
		}

		#region ISpeedProvider implementation

		public float Speed
		{
			get { return speed - worldSpeedProvider.Speed; }
		}

		#endregion
	}

	public GameObject Bullet;
	private void Shoot()
	{
		GameObject newBullet = (GameObject)Object.Instantiate(Bullet, transform.position, Quaternion.identity);
		newBullet.GetComponent<Star>().SpeedProvider = new BulletSpeedProvider(10.5f, this);
	}
}
