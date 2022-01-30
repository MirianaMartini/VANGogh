using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private Transform _empty;
    [SerializeField] private GameObject _zainoInventory;
    [SerializeField] private GameObject _zainoObj;
    [SerializeField] private GameObject _crossHair;
    [SerializeField] private GameObject _fotocamera;

    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;
    private ItemPickUp _pointingPickUp;
    private CharacterController _fpsController;
    private Vector3 _rayOrigin;
    private Grabbable _grabbedObject = null;

    //private InventoryManager Inventory = new InventoryManager();

    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        //Apertura Zaino Inventory
        if ((_grabbedObject == null) && Input.GetKeyUp(KeyCode.Tab)){
            _zainoInventory.SetActive(!_zainoInventory.activeSelf);
            _zainoObj.SetActive(!_zainoObj.activeSelf);
            InventoryManager.Instance.ListItems();
        }

        if (_grabbedObject == null)
            CheckInteraction();

        else if (_grabbedObject != null && Input.GetMouseButtonUp(1))
            Drop();

        if(Input.GetKeyUp(KeyCode.E) && _grabbedObject != null) {
            Vector3 newObjectPosition;
            
            Quaternion newObjectOrientation;
            newObjectPosition = _empty.position;
            newObjectOrientation = _empty.rotation;

            _grabbedObject.transform.position = newObjectPosition;
            _grabbedObject.transform.rotation = newObjectOrientation;
        }

        //Apparizione disapparizione CrossHair
        if(_grabbedObject != null || Input.GetMouseButton(0)) _crossHair.SetActive(false);
        else _crossHair.SetActive(true);

     

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
                if (Input.GetKeyDown(KeyCode.E) && Input.GetMouseButton(1))
                {   
                    _pointingGrabbable.Grab(gameObject);
                    Grab(_pointingGrabbable);
                }
                    
            }

            //PickUp Objects
            _pointingPickUp = hit.transform.GetComponent<ItemPickUp>();
            if(_pointingPickUp && Input.GetKeyDown(KeyCode.I)){
                _pointingPickUp.PickUp();
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
