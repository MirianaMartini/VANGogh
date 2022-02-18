using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ActivateMappa : MonoBehaviour
{
    public GameObject _cameraMappa;
    public GameObject _cameraVan;
    public FirstPersonControllerCustom FPS_firstPersonControllerScript;
    public FPSInteractionManager FPS_InteractionManagerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraMappa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_cameraVan.activeSelf){
            if(Input.GetKeyDown(KeyCode.M)){
                _cameraMappa.SetActive(!_cameraMappa.activeSelf);
                if(_cameraMappa.activeSelf){
                     FPS_firstPersonControllerScript.enabled = false;
                     FPS_InteractionManagerScript.enabled = false;
                } else {
                    FPS_firstPersonControllerScript.enabled = true;
                    FPS_InteractionManagerScript.enabled = true;
                }
            }
        }

    }
}
