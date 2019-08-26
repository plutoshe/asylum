using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Interactable
{
    [SerializeField] private bool m_locked = false;

    private Animator m_anim;

    void Start()
    {
        m_anim = gameObject.GetComponent<Animator>();
    }

    public override void Interact()
    {
        if(!m_locked)
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
}
