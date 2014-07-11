using UnityEngine;
using System.Collections;

public class MenuArma : MonoBehaviour 
{
	
	public float Speed=1.0f;
	public GameObject Direction_Ship;
	public GameObject Dir;
	public MenuShip Ship;
	
	private Transform _thisTransform;
	private Transform _DirTransform;
	private Transform _ShipTransform;
	private Transform _Ship_DirTransform;
	private Vector3 velocity;
	
	// Use this for initialization
	void Start () 
	{
		_thisTransform = transform;
		_DirTransform = Dir.transform;
		_ShipTransform = Ship.transform;
		_Ship_DirTransform = Direction_Ship.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance (_ShipTransform.position, _Ship_DirTransform.position) < 0.5f) 
		{
			Vector3 DDirection = (_DirTransform.position - _thisTransform.position).normalized;
			velocity = DDirection * Time.deltaTime * Speed;
			this.transform.position += velocity;
		}
	}
	
	
}

		

