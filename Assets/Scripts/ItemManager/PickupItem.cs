using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item itemData;
    // public GameObject effect; //
    public BoxCollider2D box;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.instance.AddItem(itemData);
            FindObjectOfType<AudioManager>().PlaySound("GetItem");
        }
    }
}
