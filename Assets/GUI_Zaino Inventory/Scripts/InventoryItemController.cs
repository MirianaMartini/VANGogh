using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
    public Item item;

    private string tag;

    public void RemoveItem() {
        tag = item.itemName;
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
        Drop();
    }

    public void AddItem(Item newItem) {
        item = newItem;
    }

    private void Drop(){
        GameObject obj = Instantiate(item.prefab);
        if (tag == "Orecchio"){
            obj.tag = tag;
        }
        obj.transform.position = InventoryManager.Instance.GetCamera().position;
    }

}
