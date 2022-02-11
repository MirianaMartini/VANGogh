using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] CharacterController _fpsController;
    [SerializeField] private float _interactionDistance;
    [SerializeField] Image[] Images;

    private Vector3 _rayOrigin;
    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(true);
        foreach(Image i in Images){
            i.color = Color.white;
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
                foreach(Image i in Images){
                    i.color = Color.red;
                }
            }           
            else if (_pointingGrabbable){
                foreach(Image i in Images){
                    i.color = Color.blue;
                }
            }
            else {
                foreach(Image i in Images){
                    i.color = Color.white;
                }
            }
        }
    }
}
