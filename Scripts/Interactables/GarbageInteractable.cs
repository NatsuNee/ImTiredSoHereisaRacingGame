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
        gameObject.SetActive(false);
        gameObj.GetComponent<FirstPersonController>().CollectedItem("garbage", 1);
    }

    public override void OnLoseFocus()
    {

    }
}
