using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ScreenBoundary : MonoBehaviour
{
    public Bounds Boundary;
    public float verticalBars = 0f;

    void Start()
    {
        Camera camera = GetComponent<Camera>();
        Vector3 min = camera.ScreenToWorldPoint(new Vector3(0, verticalBars, -camera.transform.position.z));
        Vector3 max = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height - verticalBars, -camera.transform.position.z));
        Boundary.SetMinMax(min, max);
    }
}
