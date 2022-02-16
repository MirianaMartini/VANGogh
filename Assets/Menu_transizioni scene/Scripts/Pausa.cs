using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public bool GiocoInPausa = false;
    public GameObject pausaMenuUI;

    // Update is called once per frame
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
                MettiInPausa();
            }
        }
    }

    public void Riprendi()
    {
        pausaMenuUI.SetActive(false);
        Time.timeScale = 1f;
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
