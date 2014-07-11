using UnityEngine;
using System.Collections;


public class Space : MonoBehaviour, ISpeedProvider
{
	#region ISpeedProvider implementation
	
	public float Speed
	{
		get { return Velocity.x; }
	}
	
	#endregion
	
	public Vector2 Velocity = Vector2.right;
	public Vector2 SpeedXLimits = new Vector2(0f, 5f);
	private Vector2 acceleration = Vector2.zero;
	
	public float RollScaleFactor = 2f;
		
	void Start()
	{

	}
	
	void Update()
	{				

		Velocity.x = Mathf.Clamp(Velocity.x + 0.0001f * Time.deltaTime, SpeedXLimits.x, SpeedXLimits.y);

		transform.localRotation = Quaternion.Euler(Velocity.y * RollScaleFactor, 0f, 0f);
	}
	

	
}
