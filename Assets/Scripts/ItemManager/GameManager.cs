using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>(); // จำนวนไอเทมที่เก็บได้
    public GameObject[] slots;
    public static GameManager instance; // เรียกใช้คลาสตัวนี้ได้จากสคริปอื่น
    public static bool canUnlock = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        DisplayItem();
    }
    private void DisplayItem()
    {
        for (int i = 0; i < items.Count; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite;
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count) // index in slot not over in item list
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemSprite; // stay key Icon
            }
        }
    }
    public void AddItem(Item item)
    {
        if (!items.Contains(item))
        {
            items.Add(item);
            itemNumbers.Add(1);
            canUnlock = true;
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == item)
                {
                    itemNumbers[i]++;
                }
            }
        }
        DisplayItem();
    }
    public void RemoveItem(Item item)
    {
        if(items.Contains(item)) // if items list<> have item
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (item == items[i])
                {
                    itemNumbers[i] = itemNumbers[i] - 1;  // equal number of item
                    if (itemNumbers[i] == 0)
                    {
                        canUnlock = false;
                        items.Remove(item);
                        itemNumbers.Remove(itemNumbers[i]);
                    }
                }
            }
        }
        DisplayItem();
    }
}
