using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectible : Interactable
{
    [SerializeField] private Sprite m_inventoryImage = null;
    [SerializeField] bool m_rescale = false;
    [SerializeField] Vector3 m_newScale = new Vector3(0,0,0);
    private int m_slot = 5;

    public override void Interact()
    {
        if(m_rescale)
        {
            this.gameObject.transform.localScale = m_newScale;
        }
        Inventory.Instance.PlaceItemInInventory(this.gameObject);
    }

    public Sprite GetImage()
    {
        return m_inventoryImage;
    }

    public void SetImage(Sprite newImage)
    {
        m_inventoryImage = newImage;
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
