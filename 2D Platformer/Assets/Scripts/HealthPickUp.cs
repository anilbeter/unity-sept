using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponentInChildren<PlayerStats>();

            playerStats.IncreaseHealth(heal);
            Destroy(gameObject);
        }
    }

}
