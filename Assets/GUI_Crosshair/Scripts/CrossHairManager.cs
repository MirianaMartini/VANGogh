using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] CharacterController _fpsController;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private Transform _VanCamera = null;

    [Header("Objects")]
    [SerializeField] private GameObject _crossHairDefault;
    [SerializeField] Image[] Images;
    [SerializeField] private GameObject _crossHairSelect;
    [SerializeField] Image ImageSelect;
    [SerializeField] Image[] ImagesSelect;

    private Vector3 _rayOrigin;
    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    void Start(){
        _crossHairSelect.SetActive(false);
        _crossHairDefault.SetActive(true);
        foreach(Image i in Images){
            i.color = Color.white;
        }
    }

    void Update()
    {       
        if(_VanCamera){
            if(_VanCamera.gameObject.activeSelf){
                _crossHairSelect.SetActive(false);
                _crossHairDefault.SetActive(false);
                return;
            }
        }
        _rayOrigin = _fpsCameraT.position + _fpsController.radius/4 * _fpsCameraT.forward;

        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();

            //Check if is interactable
            if (_pointingInteractable) {
                _crossHairDefault.SetActive(false);
                _crossHairSelect.SetActive(true);
                ImageSelect.color = Color.red;
                foreach(Image i in ImagesSelect){
                    i.color = Color.red;
                }
            }           
            else if (_pointingGrabbable){
                _crossHairDefault.SetActive(false);
                _crossHairSelect.SetActive(true);
                ImageSelect.color = Color.blue;
                foreach(Image i in ImagesSelect){
                    i.color = Color.blue;
                }
            }
            else {
                _crossHairSelect.SetActive(false);
                _crossHairDefault.SetActive(true);
                foreach(Image i in Images){
                    i.color = Color.white;
                }
            }
        }
        else {
            _crossHairSelect.SetActive(false);
            _crossHairDefault.SetActive(true);
            foreach(Image i in Images){
                i.color = Color.white;
            }
        }
    }
}
