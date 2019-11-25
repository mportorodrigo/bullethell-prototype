using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 200.0f;
    private Transform target;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public float damage = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = ((Vector2)target.position - rb.position).normalized;
        float rotateAmount = Vector3.Cross(moveDirection, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotationSpeed;
        rb.velocity = transform.up * speed;
    }
}
