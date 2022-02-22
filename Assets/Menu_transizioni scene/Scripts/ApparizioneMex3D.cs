using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparizioneMex3D : MonoBehaviour
{
    public GameObject testo;

    void Start(){
        testo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Personaggio")
            testo.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio")
            testo.SetActive(false);
    }
}
