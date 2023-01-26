using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageState : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // take damage "player" tag
        if (collision.gameObject.tag == "Player")
        {
            HealthState playerHealth = collision.gameObject.GetComponent<HealthState>();
            if (playerHealth != null && !HealthState.gameOver)
            {
                playerHealth.PlayerHealth(1, gameObject);
            }
        }
        // knockback when player take damage by enemy
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Knockback(transform);
        }
    }
}
