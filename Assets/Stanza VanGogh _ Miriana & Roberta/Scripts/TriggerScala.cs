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
            _FPS_Controller.m_WalkSpeed = 0.6f;
            _FPS_Controller.m_JumpSpeed = 3.5f;
            _FPS_Controller.m_StepInterval = 1.1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio"){
            _ScalaEnter = false;
            _FPS_Controller.m_WalkSpeed = 1.5f;
            _FPS_Controller.m_JumpSpeed = 5;
            _FPS_Controller.m_StepInterval = 2;
        }
    }
}
