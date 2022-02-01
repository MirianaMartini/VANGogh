using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowAlbum : MonoBehaviour
{
    public GameObject ItemContent;
    public GameObject PolaroidContent;
    public Text text_Button;
    public GameObject prefab;

    private Texture2D tex = null;
    private byte[] fileData;
    private int index;

	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(SwitchView);
         
        //Cancello le foto della cartella
        index = 0;
        while (File.Exists($"Polaroids/polaroid{index}.png")){
                File.Delete($"Polaroids/polaroid{index}.png");
                ++index;
        }
	}

    public void SwitchView() {
        if(ItemContent.activeSelf){
            ItemContent.SetActive(false);
            PolaroidContent.SetActive(true);
            text_Button.text = "Zaino";
        }
        else if(PolaroidContent.activeSelf){
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

        while (File.Exists($"Polaroids/polaroid{index}.png")){
            //Lettura Immagine e creazione sprite
            fileData = File.ReadAllBytes($"Polaroids/polaroid{index}.png");
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
            Sprite photoSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            
            //Istanzio un oggetto di tipo Polaroid in PolaroidContent
            GameObject obj = (GameObject) Instantiate(prefab, PolaroidContent.transform);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            //Inserisco le info
            itemName.text = $"Polaroid{index}";
            itemIcon.sprite = photoSprite;

            ++index;
        }
    }

/*
    public void AddItem(Item newItem) {
        item = newItem;
    }
*/

}
