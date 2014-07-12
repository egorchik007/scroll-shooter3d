using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuArma : MonoBehaviour 
{
	
	public float Speed=0.1f;
	public GameObject Dir;
	public MenuShip Ship;
	
	private Transform _thisTransform;
	private Transform _DirTransform;
	private Vector3 velocity;
	private bool move;
	

	void Start () 
	{
		_thisTransform = transform;
		_DirTransform = Dir.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		move = Ship.move;
		if (move) 
		{
			Vector3 DDirection = (_DirTransform.position - _thisTransform.position).normalized;
			velocity = DDirection * Time.deltaTime * Speed;
			this.transform.position += velocity;
		}

		if (Vector3.Distance (_thisTransform.position, _DirTransform.position) < 10.0f) 
		{
				Object.Destroy(this.gameObject);				
		}
	}
	
	
}

		

