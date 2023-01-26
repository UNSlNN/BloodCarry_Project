using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState : MonoBehaviour
{
    public int itemBlood = 0;
    public int updateStars; // show stars are collected;
    void Update()
    {
        updateStars = itemBlood;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ItemBlood")
        {
            StartCoroutine(TimerDelay(collision));
        }
    }
    IEnumerator TimerDelay(Collider2D coll)
    {
        FindObjectOfType<AudioManager>().PlaySound("GetItem");
        Destroy(coll.gameObject);
        yield return new WaitForSeconds(0.1f); // delay after get item
        itemBlood = itemBlood + 1;
    }
}
