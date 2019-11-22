using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;

    // Update is called once per frame
    void Update()
    {
        // Moves the projectile
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
