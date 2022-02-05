using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerCorvi : MonoBehaviour
{
    public MonoBehaviour voloCorviScript;

    void OnTriggerEnter(Collider other)
    {
        voloCorviScript.enabled = true;
    }

}
