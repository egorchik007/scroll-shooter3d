using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour
{
    public GameObject StarPrefab;
    public float StarAppearingFrequency = 1.0f;
    public Vector2 VerticalRange = new Vector2(-5, 7);
    public float StarFlyingDistance = 10f;

    public SpaceShip SpaceShipSpeedProvider;

    private float normalizedStarTimer;

    void Start()
    {
        normalizedStarTimer = 1.0f;
    }

    void Update()
    {
        normalizedStarTimer -= Time.deltaTime * StarAppearingFrequency * SpaceShipSpeedProvider.Speed;

        if (normalizedStarTimer <= 0.0f)
        {
            this.GenerateStar();
            normalizedStarTimer = 1.0f;
        }
    }

    public void GenerateStar()
    {
        GameObject newStarObj = (GameObject)Object.Instantiate(StarPrefab);
        Star newStar = newStarObj.GetComponent<Star>();
        newStar.SpeedProvider = SpaceShipSpeedProvider;
        newStar.FlyingDistance = StarFlyingDistance;

        float randomY = Random.Range(VerticalRange.x, VerticalRange.y);

        newStarObj.transform.position = new Vector3(transform.position.x, randomY, transform.position.z);
    }
}
