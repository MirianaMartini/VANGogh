using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSInteractionManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;
    [SerializeField] private Transform _empty;

    [Header("Pergamena")]
    [SerializeField] private Transform _emptyPergamena;
    [SerializeField] private AudioClip _pergamenaOpenAudio;
    [SerializeField] private AudioClip _pergamenaCloseAudio;

    [Header("Zaino")]
    [SerializeField] private GameObject _zainoInventory;
    [SerializeField] private GameObject _zainoObj;
    [SerializeField] private ShowAlbum _showAlbum;

    [Header("CrossHair")]
    [SerializeField] private GameObject _crossHair;
    

    private Interactable _pointingInteractable;
    private Grabbable _pointingGrabbable;
    private ItemPickUp _pointingPickUp;
    private CharacterController _fpsController;
    private Vector3 _rayOrigin;
    private Grabbable _grabbedObject = null;
    private Interactable _pergamenaShow = null;
    private Transform _originalParentPergamena;
    private AudioSource _audioSource;
    private bool init = false;


    //private InventoryManager Inventory = new InventoryManager();

    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        //Pergamena
        if(_pergamenaShow != null){
            if(Input.GetKeyDown(KeyCode.E)){
                //Faccio ritornare la pergamena nella posizione originale;
                _pointingInteractable.Interact(gameObject);
                _audioSource.clip = _pergamenaCloseAudio;
                _audioSource.Play();
                RestorePergamena();
                _pergamenaShow = null;
            }
            else return;
        }

        //Apertura Zaino Inventory
        if ((_grabbedObject == null) && Input.GetKeyUp(KeyCode.Tab) && init){
            _zainoInventory.SetActive(!_zainoInventory.activeSelf);
            _zainoObj.SetActive(!_zainoObj.activeSelf);
            InventoryManager.Instance.ListItems();
            _showAlbum.ListPolaroids();
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
        if(_grabbedObject != null || Input.GetMouseButton(0) || _pergamenaShow != null || _zainoInventory.activeSelf) 
            _crossHair.SetActive(false);
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
                if (Input.GetKeyDown(KeyCode.E)){
                    if(_pointingInteractable.tag == "Pergamena"){
                        _pergamenaShow = _pointingInteractable;
                        ShowPergamena();
                        _pergamenaShow.Interact(gameObject);
                        _audioSource.clip = _pergamenaOpenAudio;
                        _audioSource.Play();
                    } else if(_pointingInteractable.tag == "Init"){
                        _pointingInteractable.Interact(gameObject);
                        init = true;
                    } else _pointingInteractable.Interact(gameObject);
                }
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

    private void ShowPergamena(){
        Vector3 newObjectPosition;
        Quaternion newObjectOrientation;
        Vector3 newObjectScale;
        Vector3 scaleChange = new Vector3(1.2f, 1.2f, 1.2f);

        //_originalPosPergamena = _pergamenaShow.transform; //salvo la vecchia posizione
        _originalParentPergamena = _pergamenaShow.transform.parent; //salvo l'original Parent
        _pergamenaShow.transform.SetParent(_emptyPergamena); //setto il parent
        
        newObjectPosition = _emptyPergamena.position;
        newObjectOrientation = _emptyPergamena.rotation;
        newObjectScale = _emptyPergamena.lossyScale + scaleChange;

        _pergamenaShow.transform.position = newObjectPosition;
        _pergamenaShow.transform.rotation = newObjectOrientation;
        _pergamenaShow.transform.localScale = newObjectScale;                      
    }

    private void RestorePergamena(){
        Vector3 newObjectPosition;
        Quaternion newObjectOrientation;
        Vector3 newObjectScale;

        newObjectPosition = _originalParentPergamena.position;
        newObjectOrientation = _originalParentPergamena.rotation;

        _pergamenaShow.transform.position = newObjectPosition;
        _pergamenaShow.transform.rotation = newObjectOrientation;
        
        _pergamenaShow.transform.parent = _originalParentPergamena; //riporto il parent
        _pergamenaShow.transform.localScale = new Vector3(1, 1, 1);
    }
}
