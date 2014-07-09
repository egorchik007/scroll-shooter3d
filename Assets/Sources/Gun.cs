using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    class BulletSpeedProvider : ISpeedProvider
    {
        ISpeedProvider worldSpeedProvider;
        float speed;

        public BulletSpeedProvider(ISpeedProvider worldSpeedProvider, float bulletSpeed)
        {
            this.worldSpeedProvider = worldSpeedProvider;
            this.speed = bulletSpeed;
        }

        public float Speed
        {
            get { return speed - worldSpeedProvider.Speed; }
        }
    }

    public GameObject Bullet;
    public float BulletSpeed = 10.1f;
    public float ShotsPerSecond = 1f;

    private float cooldown = 0f;

    public void Update()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void Shoot(ISpeedProvider worldSpeedProvider)
    {
        if (cooldown > 0f)
        {
            return;
        }

        GameObject newBulletObj = (GameObject)Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, -90));
        Star newBullet = newBulletObj.GetComponent<Star>();
        newBullet.SpeedProvider = new BulletSpeedProvider(worldSpeedProvider, worldSpeedProvider.Speed + BulletSpeed + 0.5f);
        cooldown = 1f / ShotsPerSecond;
    }
}
