using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageInteractable : Interactable
{
    public override void OnFocus()
    {

    }

    public override void OnInteract(GameObject gameObj)
    {
        gameObj.GetComponent<FirstPersonController>().CollectedItem("garbage", 1);
        Destroy(gameObject);
    }

    public override void OnLoseFocus()
    {

    }
}
