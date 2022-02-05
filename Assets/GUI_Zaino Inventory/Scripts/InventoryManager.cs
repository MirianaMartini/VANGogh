using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;
    public Transform _fpsCameraT;

    public InventoryItemController[] InventoryItems;

    private void Awake(){
        Instance = this;
    }

    public void Add(Item item){
        Items.Add(item);
    }

    public void Remove(Item item){
        Items.Remove(item);
    }

    public void ListItems(){
        bool flag = false;
        
        foreach(var item in Items){
            foreach(Transform itemC in ItemContent){
                var tmp = itemC.transform.Find("ItemName").GetComponent<Text>();
                if(item.itemName == tmp.text){
                    flag = true;
                    continue;
                }
            }
            if(!flag){
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
                
                itemName.text = item.itemName;
                itemIcon.sprite = item.icon;
            }
            flag = false;
        }

        SetInventoryItems();
    }

    public void SetInventoryItems() {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++) {
            InventoryItems[i].AddItem(Items[i]);
        }
    }

    public Transform GetCamera(){
        return _fpsCameraT;
    }
    
}
