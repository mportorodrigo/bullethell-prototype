﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBehaviour : MonoBehaviour
{
    // Component variables
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    GameManager gameManager;

    // Behaviour variables
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float healthPoints = 10.0f;
    [SerializeField] private float damageTaken = 10.0f;
    [SerializeField] private int scoreToAdd = 10;
    [SerializeField] private float fireRate = 1.0f;
    [SerializeField] private float waitBeforeShoot = 1.0f;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        nextFire = Time.time + waitBeforeShoot;

        // Increase the enemy health points according to the selected difficulty
        healthPoints *= gameManager.selectedDifficulty;
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
        if (Time.time > nextFire && gameManager.isGameActive == true)
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player Bullet"))
        {
            // Remove the player bullet
            Destroy(collision.gameObject);

            // Deduce the health from the enemy
            healthPoints -= damageTaken;
            
            if (healthPoints <= 0)
            {
                Destroy(gameObject);
                gameManager.UpdateScore(scoreToAdd);
            }
        }
    }
}
