using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float fireRate = 1.0f;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy ship
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        Shoot();
    }

    private void Shoot()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
}
