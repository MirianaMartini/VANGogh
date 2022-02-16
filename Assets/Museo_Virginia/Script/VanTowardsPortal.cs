using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.Video;

public class VanTowardsPortal : MonoBehaviour
{
    public GameObject _vanCamera;
    public GameObject _mainCamera;
    public Animator _animatorVan;
    public GameObject Van;
    public GameObject FPV;
    public float Distanza;
    public GameObject Mura;
    public bool flag = false;

    private Vector3 _rayOrigin;
    private Interactable _pointingInteractable;
    private CharacterController _fpsController;
    private Collider[] _colliders;
    
   
    private void Start()
    {
        _mainCamera.gameObject.active = true;
        _vanCamera.gameObject.active = false;
        _animatorVan = GetComponent<Animator>();
        _fpsController = FPV.GetComponent<CharacterController>();
        _colliders = Mura.GetComponents<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        _rayOrigin = _mainCamera.transform.position + _fpsController.radius/4 * _mainCamera.transform.forward;
        Ray ray = new Ray(_rayOrigin, _mainCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Distanza)){
            _pointingInteractable = hit.transform.GetComponent<Interactable>();
            if (_pointingInteractable){
                if (_pointingInteractable.tag == "Van"){
                    if (Input.GetKeyDown(KeyCode.E)){
                        flag = true;
                        cambioCamera();
                        MoveVan();
                        delayAsync();
                    }
                }
            }
        }
        /*
        //Distanza = Vector3.Distance(Van.transform.position, FPV.transform.position);
        // rileva il tasto W e sposta in avanti
        if (Input.GetKeyDown(KeyCode.E) && Distanza < 5)
        {
            cambioCamera();
            MoveVan();
            delayAsync();
            
        }
        */
    }

    //Funzione che cambia camera
    public void cambioCamera()
    {
        if (_mainCamera.gameObject.active) //Guida VAN
        { 
            _mainCamera.gameObject.active = false;
            _vanCamera.gameObject.active = true;

        }
    }

    public void MoveVan()
    {
        if (_animatorVan == null)
            return;

        foreach(Collider c in _colliders){
            c.enabled = false;
        }
        _animatorVan.SetBool("move", true);

    }

    public async Task delayAsync() //Ritardo la scomparsa dell'orecchio cos? l'utente pu? vedere cosa prende
                                   //poi scompare cos? non deve tenerlo in mano, "come se se lo mettesse"
    {
        await Task.Delay(4000);
        SceneManager.LoadScene("Mondo");
        SceneManager.LoadScene("Città", LoadSceneMode.Additive);
    }
}
