using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private Transform _empty;

    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;

    private CharacterController _fpsController;
    private Vector3 _rayOrigin;

    private Grabbable _grabbedObject = null;

    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        if (_grabbedObject == null)
            CheckInteraction();

        else if (_grabbedObject != null && Input.GetMouseButtonUp(0))
            Drop();

        if(Input.GetKeyUp(KeyCode.E) && _grabbedObject != null) {
            Vector3 newObjectPosition;
            
            Quaternion newObjectOrientation;
            newObjectPosition = _empty.position;
            newObjectOrientation = _empty.rotation;

            _grabbedObject.transform.position = newObjectPosition;
            _grabbedObject.transform.rotation = newObjectOrientation;
        }

        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {
        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            //Check if is interactable
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            if (_pointingInteractable)
            {
                if (Input.GetKeyDown(KeyCode.E))
                    _pointingInteractable.Interact(gameObject);
            }
           
            //Check if is grabbable
            _pointingGrabbable = hit.transform.GetComponent<Grabbable>();
            if (_grabbedObject == null && _pointingGrabbable)
            {
                if (Input.GetKeyDown(KeyCode.E) && Input.GetMouseButton(0))
                {
                    _pointingGrabbable.Grab(gameObject);
                    Grab(_pointingGrabbable);
                }
                    
            }
        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractable = null;
        }
    }

    private void Drop()
    {
        if (_grabbedObject == null)
            return;

        _grabbedObject.transform.parent = _grabbedObject.OriginalParent;
        _grabbedObject.Drop();

        _grabbedObject = null;
    }

    private void Grab(Grabbable grabbable)
    {
        _grabbedObject = grabbable;
        grabbable.transform.SetParent(_fpsCameraT);
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }
}
