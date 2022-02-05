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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Image i in Images){
                    i.color = Color.white;
        }
        
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

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
