using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class Grabber : Grabbable
{
    public Material cieloGiorno = null;
    public Material cieloNotte = null;
    
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Scene _scene;
    private GameObject[] objs;
    private GameObject colorGiorno = null;
    private GameObject colorNotte = null;
    
    protected override void Start()
    {
        base.Start();
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();

        if (gameObject.tag == "Orecchio"){
            _scene = SceneManager.GetActiveScene();
            objs = _scene.GetRootGameObjects();
            foreach(GameObject obj in objs){
                if(obj.name == "PostProcessVolumeGiorno")
                    colorGiorno = obj;
                if(obj.name == "PostProcessVolumeNotte")
                    colorNotte = obj;
            }
        }
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
