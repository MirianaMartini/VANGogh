using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //Set these Textures in the Inspector
    //public Texture m_MainTexture, m_Normal, m_Metal;
    //Renderer m_Renderer;
    public Material Material1;
    public Material Material2;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //Fetch the Renderer from the GameObject
        m_Renderer = GetComponent<Renderer>();

        //Make sure to enable the Keywords
        m_Renderer.material.EnableKeyword("_NORMALMAP");
        m_Renderer.material.EnableKeyword("_METALLICGLOSSMAP");
        */
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.R) && Input.GetKeyDown(KeyCode.C))
        {
            /*
            //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
            //Set the Normal map using the Texture you assign in the Inspector
            m_Renderer.material.SetTexture("_BumpMap", m_Normal);
            //Set the Metallic Texture as a Texture you assign in the Inspector
            m_Renderer.material.SetTexture("_MetallicGlossMap", m_Metal);
            */
            GetComponent<MeshRenderer>().material = Material1;
        } 
       else if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<MeshRenderer>().material = Material2;
        }
    }
}
