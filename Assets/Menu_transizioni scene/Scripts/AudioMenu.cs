using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    public GameObject VanCamera = null;
    
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    void Update(){
        if(VanCamera != null){
            if(VanCamera.activeSelf){
                _audioSource.clip = null;
            }
        }
    }

}
