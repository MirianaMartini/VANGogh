using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudioNatura : MonoBehaviour
{
    [SerializeField] private AudioClip _audioNatura;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Personaggio")
        {
            _audioSource.clip = _audioNatura;
            _audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio")
        {
            _audioSource.clip = null;
        }
    }
}
