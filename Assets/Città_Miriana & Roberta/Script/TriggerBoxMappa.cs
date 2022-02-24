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
            firstTime = false;
            BoxMappa.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Personaggio") {
            BoxMappa.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            BoxMappa.SetActive(false);
        }
    }


}
