using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAlbum : MonoBehaviour
{
    public GameObject ItemContent;
    public GameObject PolaroidContent;
    public Text text_Button;

	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(Switch_View);
	}

    public void Switch_View() {
        if(ItemContent.activeSelf){
            ItemContent.SetActive(false);
            PolaroidContent.SetActive(true);
            text_Button.text = "Zaino";
        }
        else if(PolaroidContent.activeSelf){
            PolaroidContent.SetActive(false);
            ItemContent.SetActive(true);
            text_Button.text = "Album";
        }
    }

/*
    public void AddItem(Item newItem) {
        item = newItem;
    }
*/
}
