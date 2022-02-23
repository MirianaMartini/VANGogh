using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ShowObjects : MonoBehaviour
{
    public List<GameObject> Oggetti = new List<GameObject>();

    private string path = "ZainoObjs.txt";

    // Start is called before the first frame update
    void Start()
    {
        List<string> Objs = LeggiFile();
        foreach(GameObject obj in Oggetti){
            if (Objs.Contains(obj.name))
                obj.SetActive(true);
            else
                obj.SetActive(false);
        }
    }

    private List<string> LeggiFile(){
        //Lettura da file
        List<string> Objs = new List<string>();;
        string s;

        StreamReader sr = File.OpenText(path);
        while ((s = sr.ReadLine()) != null){
            Objs.Add(s);
        }
        sr.Close();
        return Objs;
    }
}
