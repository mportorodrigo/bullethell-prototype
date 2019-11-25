using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private GameObject target;
    private Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        moveDirection = (transform.position - target.transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }
}
