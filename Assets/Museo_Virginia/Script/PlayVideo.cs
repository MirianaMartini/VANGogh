using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public VanTowardsPortal scriptVanMove;


    // Start is called before the first frame update
    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && scriptVanMove.flag)
        {
            videoPlayer.Play();
        }
        
    }
}
