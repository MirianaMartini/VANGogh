using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerRigidBodyObj : MonoBehaviour
{
    public AudioClip audioClip;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
            Play();
    }
    
    private void Play(){
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}
