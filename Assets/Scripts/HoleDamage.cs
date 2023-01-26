using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // take damage "player" tag
        if (collision.gameObject.tag == "Player")
        {
            HealthState playerHealth = collision.gameObject.GetComponent<HealthState>();
            if (playerHealth != null)
            {
                playerHealth.PlayerHealth(5, gameObject);
            }
        }
    }
}
