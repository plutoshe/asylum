using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractController : MonoBehaviour
{

    public Image m_reticle;
    public Color m_idleColor;
    public Color m_interactColor;
    public Color m_nonInteractColor;

    //removes the mouse and locks the mouse onto the game screen
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null && !GameStateManager.Instance.IsPaused())
        {
            if(other.gameObject.GetComponent<Interactable>().CanInteract())
            {
                m_reticle.GetComponent<Image>().color = m_interactColor;      
            }
            else
            {
                m_reticle.GetComponent<Image>().color = m_nonInteractColor;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null && !GameStateManager.Instance.IsPaused())
        {
            if (Input.GetMouseButtonDown(0) && other.gameObject.GetComponent<Interactable>().CanInteract())
            {
                other.gameObject.GetComponent<Interactable>().Interact();

                if(other.gameObject.GetComponent<Collectible>() != null)
                {
                    m_reticle.GetComponent<Image>().color = m_idleColor;
                }
                else if(!other.gameObject.GetComponent<Interactable>().CanInteract())
                {
                    m_reticle.GetComponent<Image>().color = m_nonInteractColor;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null && !GameStateManager.Instance.IsPaused())
        {
            m_reticle.GetComponent<Image>().color = m_idleColor;
        }
    }
}
