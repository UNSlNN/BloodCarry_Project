using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private GameObject pressKey;
    private void Start()
    {
        pressKey.SetActive(false);
    }
    public Transform GetDestination()
    {
        return destination;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            pressKey.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            pressKey.SetActive(false);
        }
    }
}
