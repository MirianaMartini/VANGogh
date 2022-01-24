using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator _animator;

    private Vector3 _inputVector;
    private float _inputSpeed;

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
        Debug.Log(Input.GetMouseButtonDown(0));
        _animator.SetBool("grabMode", Input.GetMouseButton(0));
    }
}
