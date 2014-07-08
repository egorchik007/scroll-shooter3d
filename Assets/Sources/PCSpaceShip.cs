using UnityEngine;
using System.Collections;

public class PCSpaceShip : SpaceShip
{
	public override void Update()
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
			Move(2f * Time.deltaTime, 0f);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			Move(-2f * Time.deltaTime, 0f);
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
	}
}
