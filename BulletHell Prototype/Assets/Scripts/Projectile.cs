using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Rigidbody2D projectileRb;

    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody2D>();
        projectileRb.velocity = transform.up * speed;
    }
}
