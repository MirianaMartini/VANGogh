using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerCitta : MonoBehaviour
{   
    [SerializeField] private AudioClip _audioCitta;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Personaggio"){
            _audioSource.clip = _audioCitta;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio"){
            _audioSource.clip = null;
        }
    }
}
