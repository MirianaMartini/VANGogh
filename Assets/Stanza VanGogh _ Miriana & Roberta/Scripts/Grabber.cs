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
    public GameObject colorGiorno = null;
    public GameObject colorNotte = null;

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
            colorGiorno.SetActive(false);
            colorNotte.SetActive(true);
        }
    }

    public override void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
        if (gameObject.tag == "Orecchio")
        {
            RenderSettings.skybox = cieloGiorno;
            colorGiorno.SetActive(true);
            colorNotte.SetActive(false);
        }
    }

}
