using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class TriggerSpeedInHouse : MonoBehaviour
{
    [SerializeField] private FirstPersonControllerCustom _FPS_Controller;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Personaggio"){
            _FPS_Controller.m_WalkSpeed = 1;
            _FPS_Controller.m_JumpSpeed = 4;
            _FPS_Controller.m_StepInterval = 1.5f;
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
