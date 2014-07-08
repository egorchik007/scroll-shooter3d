using UnityEngine;
using System.Collections;

public class Orbiter : MonoBehaviour
{
	public GameObject Center = null;
	public float Speed = 0f;

	IEnumerator Start()
	{
		if (null == Center)
		{
			Debug.LogError("Can not work without Center", this);
			enabled = false;
		}
		while (this)
		{
			gameObject.transform.RotateAround(Center.transform.position, Vector3.up, Speed * Time.deltaTime);
			yield return null;
		}
	}
}
