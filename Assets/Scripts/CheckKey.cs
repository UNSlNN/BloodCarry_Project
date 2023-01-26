using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKey : MonoBehaviour
{
    public BoxCollider2D box;
    public Sprite isUnlock;
    public GameObject doorLock;
    public GameObject doorUnlock;
    public GameObject misskey;
    public bool unlock;
    public int buttonID;
    [SerializeField] private Item thisItem;
    // Check Player Have Item Key,
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        doorUnlock.SetActive(false);
        doorLock.SetActive(true);
        misskey.SetActive(false);
    }
    void Update()
    {
        UnlockDoor();
        //RemoveKey();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.canUnlock == true)
            {
                unlock = true;
            }
            if(unlock == false)
            {
                misskey.SetActive(true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.canUnlock != true)
            {
                unlock = false; //
            }
            misskey.SetActive(false);
        }
    }
    private Item GetThisItem()
    {
        for (int i = 0; i < GameManager.instance.items.Count; i++)
        {
            if (buttonID == i) // Check Item ID
            {
                thisItem = GameManager.instance.items[i]; // Get Item
            }
        }
        return thisItem;
    }
    void UnlockDoor()
    {
        if (unlock == true)
        {
            box.GetComponent<BoxCollider2D>().enabled = false;
            doorUnlock.SetActive(true);
            doorLock.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = isUnlock;
            GameManager.instance.RemoveItem(GetThisItem()); // return item, And remove it
        }
    }
    void RemoveKey()
    {
        if (ScenePlay.tryAgain)
        {
            GameManager.instance.RemoveItem(GetThisItem());
        }
    }

}
