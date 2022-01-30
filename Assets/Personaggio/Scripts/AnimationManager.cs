using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;

    private Animator _animator;
    private Vector3 _inputVector;
    private float _inputSpeed;
    private Grabbable _pointingGrabbable;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Handle the Input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _inputVector = new Vector3(h, 0, v);
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);

        UpdateAnimations();
    }

    private void UpdateAnimations()
    {   
        //Idle <-> Walking
        _animator.SetFloat("speed", _inputSpeed);

        //Idle <-> GrabMode
        _animator.SetBool("grabMode", Input.GetMouseButton(1));

        //grabMode <-> Grab
        if (_fpsCameraT.transform.childCount > 4) {
            //se i figli sono piu' di due vuol dire che e' stato grabbato un oggetto
            _animator.SetBool("grab", true);
        }
        if (Input.GetMouseButtonUp(1)) _animator.SetBool("grab", false);

        //Idle <-> NoArms-Zaino
        if (Input.GetKeyUp(KeyCode.Tab) && !_animator.GetBool("grab"))
        {
            if(_animator.GetBool("noArms-Zaino")) _animator.SetBool("noArms-Zaino", false);
            else _animator.SetBool("noArms-Zaino", true);
        }

        //Idle <-> NoArms-Foto
        if (Input.GetMouseButton(0) && !_animator.GetBool("grab"))
        {
            _animator.SetBool("noArms-Foto", Input.GetMouseButton(0));
        }

        //se NON sono in modalità foto e il NON grabbo <-> torna in Idle
        if (Input.GetMouseButtonUp(0) && !_animator.GetBool("grab"))
            _animator.SetBool("noArms-Foto", false);


    }
}
