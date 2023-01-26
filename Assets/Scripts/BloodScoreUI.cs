using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodScoreUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] int numberOfItem;
    [SerializeField] int itemKey; // number of available
    [SerializeField] ItemState availableItem;
    public Image[] keyItem;
    public Sprite fullItem;
    public Sprite emptyItem;
    public static bool zeoroItem = false;

    void Update()
    {
        CheckItemIndex();

        for (int i = 0; i < keyItem.Length; i++)
        {
            if(i < itemKey)
            {
                keyItem[i].sprite = fullItem;
            }
            else
            {
                keyItem[i].sprite = emptyItem;
            }
            //////////////////////////////////
            if(i < numberOfItem)
            {
                keyItem[i].enabled = true;
            }
            else
            {
                keyItem[i].enabled = false;
            }
        }
        if(itemKey == 0)
        {
            zeoroItem = true;
        }
    }

    void CheckItemIndex()
    {
        itemKey = availableItem.itemBlood;
    }
}
