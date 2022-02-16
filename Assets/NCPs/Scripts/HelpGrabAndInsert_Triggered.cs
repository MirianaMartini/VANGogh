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
            StartCoroutine(Apparizione_Box());
            BoxGrabAndInsert.SetActive(true);
            StartCoroutine(Durata_Box());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio" && firstTime)
            firstTime = false;
        
    }

    IEnumerator Apparizione_Box()
    {
        yield return new WaitForSeconds(5);
    }

    IEnumerator Durata_Box() 
    {
        yield return new WaitForSeconds(15);
        BoxGrabAndInsert.SetActive(false);
    }
}
