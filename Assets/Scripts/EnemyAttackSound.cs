using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("Dog");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().StopPlay("Dog");
        }
    }
}
