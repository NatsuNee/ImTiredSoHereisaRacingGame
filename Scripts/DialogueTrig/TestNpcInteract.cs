using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNpcInteract : Interactable
{
    [Header("Ink Json")]
    [SerializeField] private TextAsset inkJSON;

    public override void OnFocus()
    {

    }

    public override void OnInteract(GameObject gameObj)
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
    }

    public override void OnLoseFocus()
    {
        
    }
}
