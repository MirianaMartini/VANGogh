using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opener : Interactable
{
    public AudioClip audioOpen;
    public AudioClip audioClose;
    
    private Animator _animator;
    private bool _open = false;
    private AudioSource _audioSource;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact(GameObject caller) {
        if (_open == false){
            Open();
            PlayOpen();
        }
        else{
            Close();
            PlayClose();
        }
    }

    public void Open()
    {
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

    private void PlayOpen(){
        _audioSource.clip = audioOpen;
        _audioSource.Play();
    }

    private void PlayClose(){
        _audioSource.clip = audioClose;
        _audioSource.Play();
    }



}
