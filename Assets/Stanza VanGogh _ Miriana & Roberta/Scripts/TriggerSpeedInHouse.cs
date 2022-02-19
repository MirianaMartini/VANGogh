using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TriggerSpeedInHouse : MonoBehaviour
{
    [SerializeField] private FirstPersonControllerCustom _FPS_Controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Personaggio"){
            _FPS_Controller.m_WalkSpeed = 1.5f;
            _FPS_Controller.m_JumpSpeed = 5;
            _FPS_Controller.m_StepInterval = 2;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio"){
            _FPS_Controller.m_WalkSpeed = 2;
            _FPS_Controller.m_JumpSpeed = 6;
            _FPS_Controller.m_StepInterval = 2.5f;
        }
    }
}
