using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    [SerializeField] private GameObject cameraUI;

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Audio")]
    [SerializeField] private AudioSource cameraAudio;

    [Header("Zaino Inventory Check")]
    [SerializeField] private GameObject ZainoInventory;

    private Texture2D screenCapture;
    private bool viewingPhoto;
    private Item polaroid;
    private int index = 0;

    private void Start() 
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

    }

    private void Update()
    {

        cameraUI.SetActive(false);

        if (!ZainoInventory.activeSelf) { 

            if (Input.GetMouseButton(0)) {
                cameraUI.SetActive(true);
            }

            if (Input.GetMouseButton(0) && Input.GetKeyDown(KeyCode.Return))
            {
                //takeScreenshot
                if (!viewingPhoto)
                {
                    StartCoroutine(CapturePhoto());
                }
                else 
                {
                    RemovePhoto();
                }
            }

            if (Input.GetMouseButtonUp(0)) {
                RemovePhoto();
                cameraUI.SetActive(false);
            }

        }
    }

    IEnumerator CapturePhoto() 
    {
        cameraUI.SetActive(false);
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();

        //
        byte[] bytes = screenCapture.EncodeToPNG();
        System.IO.File.WriteAllBytes($"Polaroids/polaroid{index}.png", bytes);
        //
        ++index;

        ShowPhoto();
    }

    void ShowPhoto() 
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;

        photoFrame.SetActive(true);
        
        //do flash
        StartCoroutine(CameraFlashEffect());

        //do fading effect
        fadingAnimation.Play("PhotoFade");
    }

    IEnumerator CameraFlashEffect() 
    {
        cameraAudio.Play();
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }

    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
        cameraUI.SetActive(true);

    }


}
