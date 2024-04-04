using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public GameObject Inventory;
    public GameObject TrowButton;
    public ItemSlot[] ItemSlots;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateVisual();
        Inventory.SetActive(false);
    }

    public void ShowInventory()
    {
        Inventory.SetActive(!Inventory.activeSelf);
        DeselecktAllSlots();
    }

    public bool TryAddItem(Item itemData)
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            if (!ItemSlots[i].isFull)
            {
                ItemSlots[i].AddItem(itemData);
                UpdateVisual();
                return true;
            }
            else
            {
                if (ItemSlots[i].item.Name == itemData.Name)
                {
                    ItemSlots[i].Count += itemData.Count;
                    UpdateVisual();
                    return true;
                }
            }
        }
        UpdateVisual();
        return false;
    }

    public void TryRemoveItem()
    {
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            if(ItemSlots[i].isSelected)
            {
                ItemSlots[i].RemoveItem();
                DeselecktAllSlots();
            }
        }
    }

    public  void DeselecktAllSlots()
    {
        foreach (var slot in ItemSlots)
        {
            slot.isSelected = false;
        }
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (var slot in ItemSlots)
        {
            slot.UpdateSlotVisual();
        }
    }
}
