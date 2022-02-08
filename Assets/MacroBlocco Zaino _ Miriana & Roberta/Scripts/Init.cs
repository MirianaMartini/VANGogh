using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : Interactable
{
    [SerializeField] private GameObject DialogueBoxUI;

    // Start is called before the first frame update
    public override void Interact(GameObject caller)
    {
        Destroy(gameObject);
        DialogueBoxUI.SetActive(false);
    }
}
