using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNCP_Triggered : MonoBehaviour
{
    [SerializeField] private GameObject DialogueBoxUI;
    [SerializeField] private GameObject BoxAiutoUI;
    [SerializeField] private GameObject BoxZainoPolaroids_AiutoUI;
    [SerializeField] private GameObject PausaMenu;

    [SerializeField] private GameObject Init;

    private Animator _animator;
    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Sitting idle <-> StandUp
        if (other.gameObject.tag == "Personaggio")
        {
            _animator.SetBool("isEnter", true);
            if(!PausaMenu.activeSelf){
                DialogueBoxUI.SetActive(true);
                if (firstTime)
                    BoxAiutoUI.SetActive(true);
            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyUp(KeyCode.E)) 
        {
            BoxAiutoUI.SetActive(false);
            firstTime = false;
        }


    }

    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio")
        {
            DialogueBoxUI.SetActive(false);
            BoxAiutoUI.SetActive(false);
            _animator.SetBool("isEnter", false);

            if (Init == null) {
                BoxZainoPolaroids_AiutoUI.SetActive(true);
                StartCoroutine(Apparizione_Comandi_ZainoPolaroids());
            }
            
        }
    }

    IEnumerator Apparizione_Comandi_ZainoPolaroids()
    {
        yield return new WaitForSeconds(9);
        BoxZainoPolaroids_AiutoUI.SetActive(false);
    }
}
