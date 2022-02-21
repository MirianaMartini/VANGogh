using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoTransizione : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public TransizioneMuseo scriptTransizioneMuseo;


    // Start is called before the first frame update
    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && scriptTransizioneMuseo.flag)
        {
            videoPlayer.Play();
        }

    }
}
