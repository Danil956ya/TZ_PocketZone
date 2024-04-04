using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemList
{
    public static List<Item> GetItems()
    {
        Item[] items = Resources.LoadAll<Item>("Items");
        List<Item> Items = new List<Item>();
        Items.AddRange(items);
        return Items;
    }
}
