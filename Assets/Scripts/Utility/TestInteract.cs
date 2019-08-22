using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteract : Interactable
{
    public override void Interact()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        SetInteract(false);
    }
}
