using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanEnterExitSystem : MonoBehaviour
{
    public GameObject VanCamera;
    public GameObject FPVCamera;

    // Start is called before the first frame update
    void Start()
    {
        FPVCamera.gameObject.active = true;
        VanCamera.gameObject.active = false;
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
        if (FPVCamera.gameObject.active)
        {
            //imporre condizione che sia vicino a van o fare tramite raycasting
            FPVCamera.gameObject.active = false;
            VanCamera.gameObject.active = true;
        }
        else if (VanCamera.gameObject.active)
        {
            //TODO farlo spawnare a sx del VAN
            FPVCamera.gameObject.active = true;
            VanCamera.gameObject.active = false;
        }
    }
}
