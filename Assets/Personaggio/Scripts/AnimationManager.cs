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
        _animator.SetFloat("speed", _inputSpeed);
        _animator.SetBool("grabMode", Input.GetMouseButton(0));

        if (_fpsCameraT.transform.childCount > 2) {
            //se i figli sono piu' di due vuol dire che e' stato grabbato un oggetto
            _animator.SetBool("grab", true);
        }
        if (Input.GetMouseButtonUp(0)) _animator.SetBool("grab", false);
    }
}
