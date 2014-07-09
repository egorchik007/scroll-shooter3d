using UnityEngine;
using System.Collections;

public class Orbiter : MonoBehaviour
{
    public GameObject Center = null;
    public float Speed = 0f;

    void Start()
    {
        if (null == Center)
        {
            Debug.LogError("Can not work without Center", this);
            enabled = false;
        }
    }

    void Update()
    {
        gameObject.transform.RotateAround(Center.transform.position, Vector3.up, Speed * Time.deltaTime);
    }
}
