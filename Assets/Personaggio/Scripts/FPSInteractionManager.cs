using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSInteractionManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private bool _debugRay;
    [SerializeField] private float _interactionDistance;

    private Interactable _pointingInteractable;

    private CharacterController _fpsController;
    private Vector3 _rayOrigin;


    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _rayOrigin = _fpsCameraT.position + _fpsController.radius * _fpsCameraT.forward;

        CheckInteraction();
        Debug.Log("update...");

        if (_debugRay)
            DebugRaycast();
    }

    private void CheckInteraction()
    {
        Debug.Log("checkInteraction...");
        Ray ray = new Ray(_rayOrigin, _fpsCameraT.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactionDistance))
        {
            Debug.Log("il raggio ha colpito...");
            //Check if is interactable
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            Debug.Log(_pointingInteractable);
            if (_pointingInteractable)
            {
                Debug.Log("è interactable....");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("ho premuto il tasto E...");
                    _pointingInteractable.Interact(gameObject);
                }
            }
        }
        //If NOTHING is detected set all to null
        else
        {
            _pointingInteractable = null;
        }
    }

    private void DebugRaycast()
    {
        Debug.DrawRay(_rayOrigin, _fpsCameraT.forward * _interactionDistance, Color.red);
    }
}
