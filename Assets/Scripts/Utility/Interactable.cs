using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private bool m_interactable = true;
    public virtual void Interact()
    {
        
    }

    public bool CanInteract()
    {
        return m_interactable;
    }

    public void SetInteract(bool set)
    {
        m_interactable = set;
    }
}
