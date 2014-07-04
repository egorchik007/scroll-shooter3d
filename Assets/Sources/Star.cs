using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour 
{	
	public float StarSpeed = 20f;
	public float FlyingDistance = 20f;
    private float speed;

	[System.NonSerialized]
	public ISpeedProvider SpeedProvider;

	public virtual void Update() 
	{
        if (SpeedProvider != null)
            speed = SpeedProvider.Speed;
        else
            speed = 2f;
		float distance = StarSpeed * Time.deltaTime * speed;
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
