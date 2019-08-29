using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Interactable
{
    [SerializeField] private GameObject m_key = null;

    private Animator m_anim;

    void Start()
    {
        if(gameObject.GetComponentInParent<Animator>() != null)
        {
            m_anim = gameObject.GetComponentInParent<Animator>();
        }
        else
        {
          m_anim = gameObject.GetComponent<Animator>();
        }


        if(m_key != null)
        {
            SetInteract(false);
        }
    }

    public override void Interact()
    {
        if(CanInteract())
        {
            if(m_anim.GetBool("opening"))
            {
                m_anim.SetBool("opening", false);
            }
            else
            {
                m_anim.SetBool("opening", true);
            }
        }
    }

    private void Update()
    {
        if(!CanInteract())
        {
            if(Inventory.Instance.ContainedInInventory(m_key))
            {
                SetInteract(true);
            }
        }
    }
}
