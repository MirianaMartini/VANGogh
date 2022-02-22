using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ShowPolaroidsInMuseum : MonoBehaviour
{
    public GameObject QuadroPolaroids;
    public MeshRenderer rend;

    private Texture2D tex = null;
    private byte[] fileData;
    private string[] fileEntries;

    // Start is called before the first frame update
    void Start()
    {
        fileEntries = Directory.GetFiles("Polaroids/");
        StartCoroutine(Show());
    }

    IEnumerator Show()
    {
        while(true){
            foreach(string file in fileEntries){
                //Lettura Immagine e creazione texture
                fileData = File.ReadAllBytes(file);
                tex = new Texture2D(2, 2);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                Sprite photoSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(1, 1), 100.0f);
                rend.materials[0].mainTexture = photoSprite.texture;
                yield return new WaitForSeconds(5);
            }
        }
    }
}
