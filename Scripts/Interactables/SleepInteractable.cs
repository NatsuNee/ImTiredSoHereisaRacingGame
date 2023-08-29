using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepInteractable : Interactable
{
    [SerializeField] private GameObject trashManager;
    public override void OnFocus()
    {

    }

    public override void OnInteract(GameObject gameObj)
    {
        trashManager.GetComponent<TrashManager>().spawnalltrash();
    }

    public override void OnLoseFocus()
    {
        
    }
}
