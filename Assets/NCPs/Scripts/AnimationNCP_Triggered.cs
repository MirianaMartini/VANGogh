using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNCP_Triggered : MonoBehaviour
{
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

    }


    private void OnTriggerExit(Collider other)
    {
        _animator.SetBool("isEnter", false);
    }
}
