using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ScriptTecaFinale : MonoBehaviour
{
    public GameObject canvas;
    public GameObject tutti;
    public GameObject alcuni;
    public GameObject nessuno;
    public GameObject MessaggioFineGioco;

    private bool firstTime = true;
    private string path = "ZainoObjs.txt";
    private int count = 0;

    void Start(){
        canvas.SetActive(false);
        tutti.SetActive(false);
        alcuni.SetActive(false);
        nessuno.SetActive(false);
        MessaggioFineGioco.SetActive(false);
        count = LeggiFile();
    }

    void Update()
    {
        if(canvas.activeSelf){
            if (Input.GetKeyDown(KeyCode.Escape)){
                canvas.SetActive(false);
                Time.timeScale = 1f;
                MessaggioFineGioco.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (firstTime)
        {
           canvas.SetActive(true);
           ShowMessage();
           Time.timeScale = 0f;
           firstTime = false;
        }

    }

    private int LeggiFile(){
        //Lettura da file
        List<string> Objs = new List<string>();;
        string s;

        StreamReader sr = File.OpenText(path);
        while ((s = sr.ReadLine()) != null){
            Objs.Add(s);
        }
        sr.Close();
        return Objs.Count;
    }

    private void ShowMessage(){
        if(count == 8){
            tutti.SetActive(true);
        }
        else if(count == 0){
            nessuno.SetActive(true);
        }
        else {
            alcuni.SetActive(true);
        }
    }
}
