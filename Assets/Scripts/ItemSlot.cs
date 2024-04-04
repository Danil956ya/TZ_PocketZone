using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public int Count;
    public Item item;
    public Image Icon;
    public Image Backround;
    public TMP_Text CountText;
    public bool isFull;
    public bool isSelected;

    public void AddItem(Item itemData)
    {
        if (itemData != null)
        {
            Count = itemData.Count;
            Icon.sprite = itemData.Icon;
            item = itemData;
            isFull = true;
        }
    }

    public void RemoveItem()
    {
        if (Count > 1)
        {
            Count--;
        }
        else
        {
            Count = 0;
            Icon.sprite = null;
            item = null;
            isFull = false;
        }
    }

    public void UpdateSlotVisual()
    {
        Backround.enabled = isSelected;
        InventoryManager.Instance.TrowButton.SetActive(isSelected);
        Icon.enabled = isFull;
        CountText.enabled = Count > 1;
        CountText.text = Count.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isFull)
            {
                OnLeftClick();
            }
        }
    }

    private void OnLeftClick()
    {
        InventoryManager.Instance.DeselecktAllSlots();
        isSelected = !isSelected;
        UpdateSlotVisual();
    }
}
