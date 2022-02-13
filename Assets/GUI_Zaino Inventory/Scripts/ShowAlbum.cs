using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ShowAlbum : MonoBehaviour
{
    public GameObject ZainoInventory;
    public GameObject ItemContent;
    public GameObject PolaroidContent;
    public Text text_Button;
    public GameObject prefab;

    private Texture2D tex = null;
    private byte[] fileData;
    private string[] fileEntries;
    private int index = 0;

    void Start() {
        if (!Directory.Exists("Polaroids/")) {
            Directory.CreateDirectory("Polaroids/");
        }
        
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(SwitchView);
	}

    public void SwitchView() {
        if(ItemContent.activeSelf){
            ZainoInventory.GetComponent<ScrollRect>().content = PolaroidContent.GetComponent<RectTransform>();
            ItemContent.SetActive(false);
            PolaroidContent.SetActive(true);
            text_Button.text = "Zaino";
        }
        else if(PolaroidContent.activeSelf){
            ZainoInventory.GetComponent<ScrollRect>().content = ItemContent.GetComponent<RectTransform>();
            PolaroidContent.SetActive(false);
            ItemContent.SetActive(true);
            text_Button.text = "Album";
            InventoryManager.Instance.ListItems();
        }
    }

    public void ListPolaroids(){              
        foreach(Transform polaroid in PolaroidContent.transform){
            Destroy(polaroid.gameObject);
        } 

        index = 0;
        fileEntries = Directory.GetFiles("Polaroids/");

        foreach(string file in fileEntries){
            //Lettura Immagine e creazione sprite
            fileData = File.ReadAllBytes(file);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            Sprite photoSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            
            //Istanzio un oggetto di tipo Polaroid in PolaroidContent
            GameObject obj = (GameObject) Instantiate(prefab, PolaroidContent.transform);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            string name = getName(file);

            //Inserisco le info
            //itemName.text = $"Polaroid{index}";
            itemName.text = name;
            itemIcon.sprite = photoSprite;

            ++index;
        }
    }

    private string getName(string s){
        int index1 = s.IndexOf("/") + 1;
        int index2 = s.IndexOf(".png");
        s = s.Substring(index1, index2-index1);
        
        return s;
    }

}
