using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    public AudioClip audioClip;

    private AudioSource _audioSource;
 
    public void PickUp()
    {
        _audioSource = GetComponent<AudioSource>();
        Play();
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    private void Play(){
        Debug.Log("Sonooooooooooooooo");
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }
}
