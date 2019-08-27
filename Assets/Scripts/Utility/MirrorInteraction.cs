using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorInteraction : Interactable
{
    public override void Interact()
    {
        GameStateManager.Instance.ChangeIdentity();
    }
}
