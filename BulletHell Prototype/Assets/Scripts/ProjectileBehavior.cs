using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    [SerializeField] private int lifeSpan = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy the projectile after a few seconds
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the projectile
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
