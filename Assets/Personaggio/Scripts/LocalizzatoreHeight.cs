using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizzatoreHeight : MonoBehaviour
{
    public Transform _Localizzatore;

    // Start is called before the first frame update
    void Start()
    {
        _Localizzatore.position =  new Vector3(_Localizzatore.position.x, 49.99084f, _Localizzatore.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        _Localizzatore.position =  new Vector3(_Localizzatore.position.x, 49.99084f, _Localizzatore.position.z);
    }
}
