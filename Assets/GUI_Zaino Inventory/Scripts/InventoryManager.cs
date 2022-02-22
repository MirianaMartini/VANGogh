using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;
    public Transform _fpsCameraT;
    public InventoryItemController[] InventoryItems;

    private FileStream fs;
    private string path = "ZainoObjs.txt";

    private void Awake(){
        Instance = this;
        
        ////////////////// Delete the file if it exists and create.
        if (File.Exists(path))  File.Delete(path);
        fs = File.Create(path);   
        fs.Close(); 
        //////////////////////////////////////////////////////////    
    }

    public void Add(Item item){
        Items.Add(item);

        //Scrittura su file: aggiungo l'oggetto che ho preso
        StreamWriter sw = File.AppendText(path);
        sw.WriteLine(item.itemName);
        sw.Close();
    }

    public void Remove(Item item){
        Items.Remove(item);

        //Lettura da file
        List<string> Oggetti = new List<string>();;
        string s;

        StreamReader sr = File.OpenText(path);
        while ((s = sr.ReadLine()) != null){
            if(s != item.itemName)
                Oggetti.Add(s);
        }
        sr.Close(); 

        //Aggiorno il File
        StreamWriter sw = File.CreateText(path);
        foreach(string st in Oggetti)
            sw.WriteLine(st);
        sw.Close();
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

    private void AddText(FileStream fs, string value) {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
    
}
