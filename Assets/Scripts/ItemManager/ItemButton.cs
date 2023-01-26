using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    public int buttonID;
    private Item thisItem;
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
    public void CloseButton()
    {
        GameManager.instance.RemoveItem(GetThisItem()); // return item, And remove it
    }
}
