using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour 
{	
	public float StarSpeed = 20f;
	public float FlyingDistance = 20f;

	[System.NonSerialized]
	public ISpeedProvider SpeedProvider;
	protected float distance = 0f;

	public virtual void Update() 
	{
		distance = StarSpeed * Time.deltaTime * SpeedProvider.Speed;
		FlyingDistance -= Mathf.Abs(distance);

		Vector3 position = transform.position;
		position.x -= distance;
		transform.position = position;

		if (FlyingDistance < 0f)
		{
			Object.Destroy(gameObject);
		}
	}
}
