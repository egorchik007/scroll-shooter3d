using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    public Vector3 RotationSpeed = Vector3.zero;
    public bool randomRotation = false;
    public bool onlyZRotation = false;
    Vector3 localrspd;
    void Start()
    {
        if (randomRotation)
            localrspd = new Vector3(Random.value, Random.value, Random.value);

    }
    void Update()
    {
        gameObject.transform.Rotate((RotationSpeed + localrspd * 180) * Time.deltaTime);
        if (onlyZRotation)
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
    }
}
