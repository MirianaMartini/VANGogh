using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    public void RemoveItem() {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
        Drop();
    }

    public void AddItem(Item newItem) {
        item = newItem;
    }

    private void Drop(){
        GameObject obj = Instantiate(item.prefab);
        obj.transform.position = InventoryManager.Instance.GetCamera().position;
    }

}
