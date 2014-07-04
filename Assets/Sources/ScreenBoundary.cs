using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ScreenBoundary : MonoBehaviour
{
	public Bounds Boundary;

	void Start()
	{
		Camera camera = GetComponent<Camera>();
		Vector3 min = camera.ScreenToWorldPoint(new Vector3(0, 0, -camera.transform.position.z));
		Vector3 max = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -camera.transform.position.z));
		Boundary.SetMinMax(min, max);
	}
}
