using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    public Material cieloGiorno;
    public Material cieloNotte;
    public GameObject orecchio;
    public int ritardoScomparsaOrecchio;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = cieloGiorno;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //TODO Cambiare con orecchio preso
        {
            RenderSettings.skybox = cieloNotte;
            delayAsync();            
        }
    }
    public async Task delayAsync() //Ritardo la scomparsa dell'orecchio cos� l'utente pu� vedere cosa prende
                                    //poi scompare cos� non deve tenerlo in mano, "come se se lo mettesse"
    {
        await Task.Delay(ritardoScomparsaOrecchio);
        orecchio.gameObject.active = false;
    }
}



