using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Scriptable Objects/Grocery Item")]
public class GroceryItem : ScriptableObject
{
    public string itemName;
    [SerializeField] [Range(3,5)] int itemRarity;
    [SerializeField] Sprite itemImage;
    [SerializeField] Sprite itemBG;

    public Sprite GetItemImage()
    {
        return itemImage;
    }

    public Sprite GetItemBG()
    {
        return itemBG;
    }
}
