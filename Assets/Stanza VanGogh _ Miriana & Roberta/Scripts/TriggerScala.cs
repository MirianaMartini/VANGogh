using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TriggerScala : MonoBehaviour
{
    [SerializeField] private FirstPersonControllerCustom _FPS_Controller;
    public bool _ScalaEnter = false;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Personaggio"){
            _ScalaEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio"){
            _ScalaEnter = false;
        }
    }
}
