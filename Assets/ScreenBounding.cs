using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ScreenBounding : MonoBehaviour
{
	private Bounds bounds;
	public Bounds Bounds
	{
		get { return bounds; }
	}

	void Start()
	{
		Camera camera = GetComponent<Camera>();
		Vector3 min = camera.ScreenToWorldPoint(new Vector3(0f, 0f, -transform.position.z));
		min.z = -1;
		Vector3 max = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -transform.position.z));
		max.z = 1;
		bounds.SetMinMax(min, max);
	}
}
