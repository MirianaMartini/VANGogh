using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public bool GiocoInPausa = false;
    public GameObject pausaMenuUI;

    private bool flag = false;
    private bool firstTime = true;

    void Start(){
        if(SceneManager.GetActiveScene().name == "Museo_Ritorno") firstTime = false;
        if(SceneManager.GetActiveScene().name == "Museo") firstTime = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (GiocoInPausa)
            {
                Riprendi();
            }
            else
            {
                if(Time.timeScale == 0f && !firstTime) flag = true;
                else {
                    flag = false;
                    firstTime = false;
                }
                MettiInPausa();
            }
        }
    }

    public void Riprendi()
    {
        pausaMenuUI.SetActive(false);
        if(!flag) Time.timeScale = 1f;
        GiocoInPausa = false;
    }

    void MettiInPausa()
    {
        pausaMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GiocoInPausa = true;
    }

    public void Home()
    {
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.Quit();
        SceneManager.LoadScene("Scena0_Menu");
        //pausaMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GiocoInPausa = false;
    }

    private void Awake()
    {
        DontDestroyOnLoad(pausaMenuUI);
    }
}
