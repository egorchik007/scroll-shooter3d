using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public Transform Target;
    public float Speed = 5.0f;
    public SpaceShip Ship;
    public float CollisionRadius = 0.65f;
    public ScreenBoundary Boundary;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < Boundary.Boundary.min.x)
        {
            Object.Destroy(gameObject);
        }

        Vector3 direction = (Target.position - this.transform.position).normalized;
        Vector3 velocity = new Vector3(-Speed * Time.fixedDeltaTime * Ship.Speed, direction.y * Speed * Time.fixedDeltaTime);

        /*if (velocity.sqrMagnitude < direction.sqrMagnitude)
        {
            this.transform.position += velocity;
        }
        else
        {
            this.transform.position = Target.position;
        }*/
        transform.position += velocity;

        if (direction.magnitude < 1.0f)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
