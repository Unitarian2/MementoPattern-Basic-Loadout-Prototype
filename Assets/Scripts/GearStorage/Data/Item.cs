using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "GearStorage/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
    public ItemType type;
}

public enum ItemType
{
    Helmet,Boots,Arms,Body,Weapon
}
