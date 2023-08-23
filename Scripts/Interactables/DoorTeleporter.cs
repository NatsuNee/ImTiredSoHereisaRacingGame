using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleporter : Interactable
{
    [Header("TeleportData")]
    [SerializeField] private string teleportLabel;
    [SerializeField] private GameObject finalTeleportSpot;

    private void Start()
    {
        
    }

    public override void OnFocus()
    {

    }

    public override void OnInteract(GameObject gameObj)
    {
        gameObj.transform.SetLocalPositionAndRotation(finalTeleportSpot.transform.position, finalTeleportSpot.transform.rotation);
    }

    public override void OnLoseFocus()
    {

    }
}
