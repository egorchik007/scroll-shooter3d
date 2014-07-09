using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Gun))]
public class Droid : MonoBehaviour, ISpeedProvider 
{		
	public float Speed
	{
		get { return -Velocity.x; }
	}	
	
	public Vector2 Velocity = Vector2.right;
	public float moveSpeed = 5.0f;
	public Transform explosion;
	public SpaceShip Ship;
	public float CollisionRadius = 0.65f;
	public ScreenBoundary Boundary;
	
	private Transform _thisTransform;
	private Transform _playerTransform;
	private Gun[] gun;
	private Vector3 Rand;
	private Vector3 velocity;
	private bool agr = true;
	
	
	public void Start()
	{	
		Rand = new Vector3 (Random.Range (1.0f, 2.0f), Random.Range (-3.5f, 6.0f), 0);
		
		// Получаем компонент трансформации объекта, к которому привязан данный компонент
		_thisTransform = transform;
		
		// Получаем компонент трансформации игрока
		_playerTransform = Ship.transform;
		
		gun = GetComponents<Gun>();
	}
	
	
	public void Update()
	{
		// направление на игрока
		Vector3 playerDirection = (_playerTransform.position - _thisTransform.position).normalized;
		
		if (Vector3.Distance (_playerTransform.position, _thisTransform.position) > 7.0f && agr) 
		{
			velocity = playerDirection * moveSpeed * Time.deltaTime * Ship.Speed;
			this.transform.position += velocity;
		}
		
		else 
		{
			velocity = Rand * moveSpeed * Time.deltaTime * Ship.Speed;
			agr = false;
		}
		
		// угол поворота на игрока
		float angle = Vector3.Angle(_thisTransform.forward, playerDirection);
		
		// Вычисляем прямой поворот на игрока
		Quaternion rot = Quaternion.LookRotation(_playerTransform.position - _thisTransform.position);
		
		// поворачиваем врага на игрока с учетом скорости поворота
		
		_thisTransform.rotation = Quaternion.Slerp(_thisTransform.rotation, rot,  angle);
		
		gun [0].Shoot (this);
		Move(Velocity.x, Velocity.y);		
	}
	
	private void Move(float x, float y)
	{
		Vector3 newPos = transform.position + velocity;
		if (Boundary.Boundary.Contains(newPos))
		{
			transform.position = newPos;
		}
		else
		{
			Rand = new Vector3 (Random.Range (1.0f, 2.0f), Random.Range (-3.5f, 6.0f), 0);
		}
	}
}