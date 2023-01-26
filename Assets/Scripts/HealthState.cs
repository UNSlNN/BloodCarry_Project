using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthState : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] public int currentHealth;
    [SerializeField] private int maxHealth = 5;
    public static bool gameOver;

    [Header("Health bar Components")]
    public Image[] healthbar;

    void Start()
    {
        gameOver = false;
        currentHealth = maxHealth;
    }

    void Update()
    {
        HealthBar();
    }

    void HealthBar()
    {
        for (int i = 0; i < healthbar.Length; i++)
        {
            healthbar[i].enabled = !CheckhealthIndex(currentHealth, i);
        }
    }

    bool CheckhealthIndex(int health, int pointNumber)
    {
        return (pointNumber * 1 >= health);
    }

    public void PlayerHealth(int damageAmount, GameObject damageFromObject) // (take damage, by enemy)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().PlaySound("Lose");
            gameOver = true;
            Timer.isFinnished = false;
        }
    }


}
