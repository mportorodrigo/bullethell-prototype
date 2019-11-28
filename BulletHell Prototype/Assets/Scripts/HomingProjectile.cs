using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 200.0f;
    private GameManager gameManager;
    private Rigidbody2D projectileRb;
    private Vector2 moveDirection;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        target = GameObject.Find("Player").transform;
        projectileRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameManager.isGameActive)
        {
            moveDirection = ((Vector2)target.position - projectileRb.position).normalized;
            float rotateAmount = Vector3.Cross(moveDirection, transform.up).z;

            projectileRb.angularVelocity = -rotateAmount * rotationSpeed;
        }
        projectileRb.velocity = transform.up * speed;
    }
}
