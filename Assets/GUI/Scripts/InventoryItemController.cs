using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public void RemoveItem() {
        Debug.Log(item);
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem) {
        item = newItem;
    }

}
