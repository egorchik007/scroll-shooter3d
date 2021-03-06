﻿using UnityEngine;
using System.Collections;

public class MenuShip : MonoBehaviour 
{

	public float Speed=1.0f;
	public GameObject Direction;
	public bool move=false;

	private Transform _thisTransform;
	private Transform _DirTransform;
	private Vector3 velocity;

	// Use this for initialization
	void Start () 
	{
		_thisTransform = transform;
		_DirTransform = Direction.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 DDirection = (_DirTransform.position - _thisTransform.position).normalized;
		velocity = DDirection *  Time.deltaTime * Speed;
		this.transform.position += velocity;

		if (Vector3.Distance (_thisTransform.position, _DirTransform.position) < 3.0f) 
		{
						move = true;
						Object.Destroy (this.gameObject);
		}
	}


}
