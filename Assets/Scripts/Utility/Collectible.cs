using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Interactable
{
    [SerializeField] private Sprite m_inventoryImage = null;
    private int m_slot = 5;

    public override void Interact()
    {
        Inventory.Instance.PlaceItemInInventory(this.gameObject);
    }

    public Sprite GetImage()
    {
        return m_inventoryImage;
    }

    public void SetSlot(int slot)
    {
        m_slot = slot;
    }

    public int GetSlot()
    {
        return m_slot;
    }
}
