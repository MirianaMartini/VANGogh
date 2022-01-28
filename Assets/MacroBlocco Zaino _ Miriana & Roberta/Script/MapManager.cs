using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Interactable
{
    [SerializeField] private GameObject _animationObject;
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private Transform _empty;
    private Animator _animator;
    private bool _open = false;
    private bool _idle;

    void Start()
    {
        _animator = _animationObject.GetComponent<Animator>();
    }

    public override void Interact(GameObject caller)
    {
        if (_open == false)
            Open();
        else
        {
            Close();
            Idle();
        }
    }

    public void Open()
    {
        if (_animator == null)
            return;

        _idle = false;
        _animator.SetBool("idle", _idle);

        //settiamo la posizione della pergamena nella viewport
        Vector3 newObjectPosition;

        Quaternion newObjectOrientation;
        newObjectPosition = _empty.position;
        newObjectOrientation = _empty.localRotation;

        _animationObject.transform.position = newObjectPosition;
        _animationObject.transform.rotation = newObjectOrientation;
        
        //imparentiamo la pergamena alla camera 
        _animationObject.transform.SetParent(_fpsCameraT);

        //attiviamo l'animazione della camera
        _open = true;
        _animator.SetBool("open", _open);
    }

    public void Close()
    {
        if (_animator == null)
            return;

        _idle = false;
        _animator.SetBool("idle", _idle);

        _open = false;
        _animator.SetBool("open", _open);

       // _animationObject.transform.parent = null;
    }

    public void Idle()
    {
        if (_animator == null)
            return;

        _idle = true;
        _animator.SetBool("idle", _idle);

        _open = false;
        _animator.SetBool("open", _open);

       // _animator.Play("Base Layer.Chiusura", -1, 0);
        _animationObject.transform.parent = null;
    }

}
