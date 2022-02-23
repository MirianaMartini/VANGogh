using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxMappa : MonoBehaviour
{
    [SerializeField] private GameObject BoxMappa;
    private bool firstTime = true;

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.tag == "Personaggio" && firstTime) {
            BoxMappa.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Personaggio") {
            firstTime = false;
            BoxMappa.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            firstTime = false;
            BoxMappa.SetActive(false);
        }
    }


}
