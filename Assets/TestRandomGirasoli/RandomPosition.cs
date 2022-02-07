using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public int numeroGirasoli;
    public int scalaGirasoli;
    public int rotazioneGirasoli;
    public Terrain terrain;
    private int terrainWidth; // terrain size (x) 
    private int terrainLength; // terrain size (z) 
    private int terrainPosX; // terrain position x 
    private int terrainPosZ; // terrain position z 

    public GameObject[] girasoli;
    private string[] arrayGirasoli = {"girasole1", "girasole9"}; 

    // Start is called before the first frame update
    void Start()
    {
        // terrain size x 
        terrainWidth = (int)terrain.terrainData.size.x;
        // terrain size z 
        terrainLength = (int)terrain.terrainData.size.z;
        // terrain x position 
        terrainPosX = (int)terrain.transform.position.x;
        // terrain z position 
        terrainPosZ = (int)terrain.transform.position.z;
        StartCoroutine(spawn());
    }
    
    IEnumerator spawn()
    {
        for (var i = 0; i < numeroGirasoli; i++)
        {
            int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            int posz = Random.Range(terrainPosZ, terrainPosZ + terrainWidth);
            float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz));
            int rotz = (int)Random.Range(0.0f + rotazioneGirasoli, 135.0f + rotazioneGirasoli);
            
            GameObject nuovoGirasole = (GameObject)Instantiate(girasoli[Random.Range(0, girasoli.Length)], new Vector3(posx, posy, posz), Quaternion.identity);
            nuovoGirasole.transform.Rotate(-90.0f, 0.0f, rotz, Space.Self);
            nuovoGirasole.transform.localScale = new Vector3(scalaGirasoli, scalaGirasoli, scalaGirasoli);
            yield return null;
        }
    }
   
}
