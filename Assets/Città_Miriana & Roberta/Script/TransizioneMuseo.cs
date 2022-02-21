using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.Video;

public class TransizioneMuseo : MonoBehaviour
{
    [SerializeField] private GameObject VAN;
    [SerializeField] private GameObject VAN_Museo;
    public bool flag = false;
    public GameObject Palazzo;
    private Collider _colliderPalazzo;
    private Collider[] _colliders;
    [SerializeField] private GameObject text;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _colliderPalazzo = Palazzo.GetComponent<Collider>();
        _colliders = VAN_Museo.GetComponents<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Personaggio" || other.gameObject.tag == "Van")
            text.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Van")
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.Log("B pressed");
                flag = true;
                VAN.SetActive(false);
                VAN_Museo.SetActive(true);
                StartCoroutine(Attesa());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Personaggio" || other.gameObject.tag == "Van")
            text.SetActive(false);
    }


    IEnumerator Attesa()
    {
        text.SetActive(false);
        yield return new WaitForSeconds(7);
        MoveVan();
        delayAsync();
    }

    public void MoveVan()
    {
     
         if (_animator == null)
             return;

        _colliderPalazzo.enabled = false;
        foreach (Collider c in _colliders)
        {
            c.enabled = false;
        }

        _animator.SetBool("move", true);
        
    }
    
    public async Task delayAsync() 
    {
        await Task.Delay(3000);
        SceneManager.LoadScene("Museo_Ritorno");

    }
    
}
