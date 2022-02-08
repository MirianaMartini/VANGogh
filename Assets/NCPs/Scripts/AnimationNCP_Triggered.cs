using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNCP_Triggered : MonoBehaviour
{
    [SerializeField] private GameObject DialogueBoxUI;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Sitting idle <-> StandUp
        _animator.SetBool("isEnter", true);
        DialogueBoxUI.SetActive(true);

    }


    private void OnTriggerExit(Collider other)
    {
        DialogueBoxUI.SetActive(false);
        _animator.SetBool("isEnter", false);
    }
}
