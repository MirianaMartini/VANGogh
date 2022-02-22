using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benvenuto : MonoBehaviour
{
    public GameObject canvas;
    private bool firstTime = true;

    void Start(){
        canvas.SetActive(false);
    }

    void Update()
    {
        if(canvas.activeSelf){
            if (Input.GetKeyDown(KeyCode.Escape)){
                canvas.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ciaooooooooo");
        if (firstTime)
        {
           canvas.SetActive(true);
           Time.timeScale = 0f;
           firstTime = false;
        }

    }
}
