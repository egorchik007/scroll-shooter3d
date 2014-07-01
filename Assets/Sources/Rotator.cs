using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
	public Vector3 RotationSpeed = Vector3.zero;

	void Update()
	{
		gameObject.transform.Rotate(RotationSpeed * Time.deltaTime);
	}
}
