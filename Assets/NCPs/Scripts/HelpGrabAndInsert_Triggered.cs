using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpGrabAndInsert_Triggered : MonoBehaviour
{
    [SerializeField] private GameObject _FPS_Controller;
    [SerializeField] private GameObject BoxGrabAndInsert;

    private bool firstTime = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Personaggio" && firstTime) { 
            BoxGrabAndInsert.SetActive(true);
            StartCoroutine(Durata_Box());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio" && firstTime)
            firstTime = false;
        
    }

    IEnumerator Durata_Box() 
    {
        yield return new WaitForSeconds(7);
        BoxGrabAndInsert.SetActive(false);
    }
}
