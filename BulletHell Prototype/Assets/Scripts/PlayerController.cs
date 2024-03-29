﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Component variables
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private TextMeshProUGUI healthText;
    private GameManager gameManager;

    // Behavior variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float healthPoints = 30.0f;
    [SerializeField] private float baseDamage = 5.0f;

    // Input variables
    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        healthText.text = "HP: " + healthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        transform.Translate(Vector3.up * Time.deltaTime * verticalInput * speed);

        // Shoot a projectile
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy Bullet"))
        {
            // Remove the enemy bullet
            Destroy(collision.gameObject);

            // Cause damage to the player based on baseDamage multiplied by difficulty
            healthPoints -= baseDamage * gameManager.selectedDifficulty;
            healthText.text = "HP: " + healthPoints;

            if (healthPoints <= 0)
            {
                gameManager.GameOver();
                gameObject.SetActive(false);
            }
        }
    }
}
