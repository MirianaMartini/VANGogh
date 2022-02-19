using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Grabber : Grabbable
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public Material cieloGiorno = null;
    public Material cieloNotte = null;
    public GameObject DirectionalLight1 = null;
    public GameObject DirectionalLight2 = null;

    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void Grab(GameObject grabebr)
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        if (gameObject.tag == "Orecchio")
        {
            RenderSettings.skybox = cieloNotte;
            //DirectionalLight1.SetActive(false);
            DirectionalLight2.SetActive(false);
        }
    }

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
        if (gameObject.tag == "Orecchio")
        {
            RenderSettings.skybox = cieloGiorno;
            //DirectionalLight1.SetActive(true);
            DirectionalLight2.SetActive(true);
        }
    }

}
