using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiAudio : MonoBehaviour
{
    public int Passi = 1; //1 = passi_citta' , 2 = passi_mondo

    private Collider[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        colliders = GetComponents<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Personaggio")
        {
            Passi = 1; //Passi_citta'
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio")
        {
            Passi = 2; //Passi_Mondo
        }
    }
}
