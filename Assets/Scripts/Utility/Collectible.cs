using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    public override void Interact()
    {
        Inventory.Instance.PlaceItemInInventory(this.gameObject);
    }
}
