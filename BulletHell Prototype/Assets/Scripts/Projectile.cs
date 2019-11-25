using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    public float damage = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Moves the projectile
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
