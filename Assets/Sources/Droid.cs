using UnityEngine;
using System.Collections;

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
	public float bounce = 1.2f;
	
	private Transform _thisTransform;
	private Transform _playerTransform;
	private Gun[] gun;
	private Vector3 Rand;
	private Vector3 velocity;
	private bool agr = true;		
	
	public void Start()
	{	
		Rand = new Vector3 (Random.Range (0.0f, 3.0f), Random.Range (-3.5f, 6.0f), 0);
		
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
		
		if (Vector3.Distance (_playerTransform.position, _thisTransform.position) > 10.0f && agr) 
		{
			velocity = playerDirection * moveSpeed * Time.deltaTime * Ship.Speed;
			//this.transform.position += velocity;
		}
		
		else 
		{
			velocity = Rand * moveSpeed * Time.deltaTime * Ship.Speed/bounce;
			agr = false;
		}			
		if (this.transform.position.x >= 10) 
		{				
			velocity = playerDirection * moveSpeed * Time.deltaTime * Ship.Speed;
			agr=true;
			Rand = new Vector3 (Random.Range (0.0f, 2.0f), Random.Range (-3.5f, 6.0f), 0);
		}
		// угол поворота на игрока
		float angle = Vector3.Angle(_thisTransform.forward, playerDirection);
		
		// Вычисляем прямой поворот на игрока
		Quaternion rot = Quaternion.LookRotation(_playerTransform.position - _thisTransform.position);
		
		// поворачиваем врага на игрока с учетом скорости поворота
		
		_thisTransform.rotation = Quaternion.Slerp(_thisTransform.rotation, rot,  angle);
		
		gun [0].Shoot (this);
		Move();	
		
	}
	
	private void Move()
	{

		Vector3 newPos = transform.position + velocity;

		if (newPos.x < 11.0f && newPos.x > -1.0f && newPos.y < 6.0f && newPos.y > -4.0f) 
		{
						transform.position = newPos;				
		} 
		else 
		{
						Rand = new Vector3 (Random.Range (0.0f, 2.0f), Random.Range (-3.5f, 6.0f), 0);
						velocity = Rand * moveSpeed * Time.deltaTime * Ship.Speed / bounce;					
		}
		/*if (Boundary.Boundary.Contains(newPos))
		{
			transform.position = newPos;
		}
		else
		{
			Rand = new Vector3 (Random.Range (0.0f, 2.0f), Random.Range (-3.5f, 6.0f), 0);
			velocity = Rand * moveSpeed * Time.deltaTime * Ship.Speed/bounce;	
		}*/
	}
}