using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.Video;

public class VanTowardsPortal : MonoBehaviour
{
    public GameObject _vanCamera;
    public GameObject _mainCamera;
    public Animator _animatorVan;
   
    private void Start()
    {
        _mainCamera.gameObject.active = true;
        _vanCamera.gameObject.active = false;
        _animatorVan = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        // rileva il tasto W e sposta in avanti
        if (Input.GetKeyDown(KeyCode.V))
        {
            cambioCamera();
            MoveVan();
            delayAsync();
            
        }
    }

    //Funzione che cambia camera
    public void cambioCamera()
    {
        if (_mainCamera.gameObject.active) //Guida VAN
        { 
            _mainCamera.gameObject.active = false;
            _vanCamera.gameObject.active = true;

        }
    }

    public void MoveVan()
    {
        if (_animatorVan == null)
            return;

      _animatorVan.SetBool("move", true);

    }

    public async Task delayAsync() //Ritardo la scomparsa dell'orecchio cos? l'utente pu? vedere cosa prende
                                   //poi scompare cos? non deve tenerlo in mano, "come se se lo mettesse"
    {
        await Task.Delay(3000);
        SceneManager.LoadScene("Mondo");
        SceneManager.LoadScene("Città");
    }
}
