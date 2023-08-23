using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : Interactable
{
    public override void OnFocus()
    {
        
    }

    public override void OnInteract(GameObject gameObj)
    {
        print("INTERACTED WITH " + gameObj.name);
    }

    public override void OnLoseFocus()
    {
        print("STOPPED LOOKING AT " + gameObject.name);
    }
}
