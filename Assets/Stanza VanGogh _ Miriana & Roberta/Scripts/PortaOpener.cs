using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaOpener : MonoBehaviour
{
    private Animator _animator;
    private bool _open = false;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if (_open == false)
                Open();
            else 
                Close();
    }

    public void Open() {
        if (_animator == null)
            return;

        _open = true;
        _animator.SetBool("open", _open);
    }

    public void Close()
    {
        if (_animator == null)
            return;

        _open = false;
        _animator.SetBool("open", _open);
    }




}
