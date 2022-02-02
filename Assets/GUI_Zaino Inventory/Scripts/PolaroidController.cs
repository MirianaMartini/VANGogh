using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class PolaroidController : MonoBehaviour
{
    public Button removeButton;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
		removeButton.onClick.AddListener(RemovePolaroid);
    }

    // Update is called once per frame
    public void RemovePolaroid()
    {
        if (File.Exists($"Polaroids/{text.text}.png")){
            File.Delete($"Polaroids/{text.text}.png");
            Destroy(gameObject);
        }
    }
}
