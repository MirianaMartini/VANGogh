using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PremiH : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            gameObject.active = false;
            Time.timeScale = 1f;
        }
        else{
            Time.timeScale = 0f;
        }
    }
}
