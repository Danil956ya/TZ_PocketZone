using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Item ItemData;
    public Image Icon;

    private void Start()
    {
        Icon.sprite = ItemData.Icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Charapter>())
        {
            if(InventoryManager.Instance.TryAddItem(ItemData) == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
