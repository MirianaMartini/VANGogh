using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PergamenaAnimator : Interactable
{
    [SerializeField] private GameObject DialogueBoxUI;

    private Animator _animator;
    private bool _open = false;
    private bool _canvas;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public override void Interact(GameObject caller) {
        if (DialogueBoxUI == null)
        {
            if (_open == false)
                Open_N();
            else
                Close_N();
        }

        else
        {
            if (_open == false)
                Open();
            else
                Close();
        }
    }

    public void Open()
    {
        if (DialogueBoxUI.activeSelf)
        {
            DialogueBoxUI.SetActive(false);
            _canvas = true;
        }

        
        if (_animator == null)
            return;

        _open = true;
        _animator.SetBool("open", _open);
    }

    public void Close()
    {
        if (_canvas) {
            DialogueBoxUI.SetActive(true);
            _canvas = false;
        }

        if (_animator == null)
            return;

        _open = false;
        _animator.SetBool("open", _open);
    }

    public void Open_N()
    {
       
        if (_animator == null)
            return;

        _open = true;
        _animator.SetBool("open", _open);
    }

    public void Close_N()
    {

        if (_animator == null)
            return;

        _open = false;
        _animator.SetBool("open", _open);
    }
}
