using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanEnterExitSystem : MonoBehaviour
{
    public GameObject VanCamera;
    public GameObject FPVCamera;
    public Transform Van;
    public Transform FPV;
    public MonoBehaviour GuidaVanScript;

    // Start is called before the first frame update
    void Start()
    {
        FPVCamera.gameObject.active = true;
        VanCamera.gameObject.active = false;
        GuidaVanScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            cambioCamera();
        }
    }

    //Funzione che cambia camera
    public void cambioCamera()
    {
        if (FPVCamera.gameObject.active) //Guida VAN
        {
            
            //imporre condizione che sia vicino a van o fare tramite raycasting 
            FPVCamera.gameObject.active = false;
            VanCamera.gameObject.active = true;
            GuidaVanScript.enabled = true;
            //Metto controller sul Van
            FPV.transform.SetParent(Van);
            

        }
        else if (VanCamera.gameObject.active) //Muove personaggio
        {
            FPVCamera.gameObject.active = true;
            VanCamera.gameObject.active = false;
            //Disattivo script che permette di guidare il van
            GuidaVanScript.enabled = false;
            //Spawnare a sx del VAN
            FPV.transform.SetParent(null);            
        }
    }
}
