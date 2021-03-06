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
    public float Distanza;
    public GameObject _crossHair;
    public GameObject PausaMenu;
    public GameObject BoxInizio;
    public GameObject _cameraMappa;

    //Audio
    private AudioSource audioSource;
    private float pitchFromCar;
    private float minPitch = 0.1f;
    private bool flag = false;
    private bool firstTime = true;


    // Start is called before the first frame update
    void Start()
    {
        FPVCamera.SetActive(true);
        VanCamera.SetActive(false);
        GuidaVanScript.enabled = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_cameraMappa.activeSelf){
            Distanza = Vector3.Distance(Van.transform.position, FPV.transform.position);
            if(firstTime){
                cambioCamera();
                BoxInizio.SetActive(true);
                firstTime = false;
            }
            else {
                if (Input.GetKeyDown(KeyCode.E) && Distanza < 3)
                {
                    if(BoxInizio.activeSelf) BoxInizio.SetActive(false);
                    cambioCamera();
                }
            }

            ////////////////////////////////////////
            if (flag){
                if (GuidaVan.cc.carSpeed >= 0)
                    pitchFromCar = GuidaVan.cc.carSpeed * 0.04f;
                else 
                    pitchFromCar = GuidaVan.cc.carSpeed * 0.008f;

                if (pitchFromCar <= minPitch)
                    audioSource.pitch = minPitch;
                else
                    audioSource.pitch = pitchFromCar;
            }
            /////////////////////////////////////////
            if (!PausaMenu.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    //Funzione che cambia camera
    public void cambioCamera()
    {
        if (FPVCamera.gameObject.activeSelf) //Guida VAN
        {
            //imporre condizione che sia vicino a van o fare tramite raycasting 
            flag = true;
            FPVCamera.SetActive(false);
            VanCamera.SetActive(true);
            _crossHair.SetActive(false);
            GuidaVanScript.enabled = true;
            //Metto controller sul Van
            FPV.transform.SetParent(Van);           
            audioSource.pitch = minPitch;
        }
        else if (VanCamera.gameObject.activeSelf) //Muove personaggio
        {
            flag = false;
            FPVCamera.SetActive(true);
            VanCamera.SetActive(false);
            _crossHair.SetActive(true);
            //Disattivo script che permette di guidare il van
            GuidaVanScript.enabled = false;
            //Spawnare a sx del VAN
            FPV.transform.SetParent(null);
            audioSource.pitch = 0;
        }
    }
}
