using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractController : MonoBehaviour
{

    public Image m_reticle;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            if(other.gameObject.GetComponent<Interactable>().CanInteract())
            {
                m_reticle.GetComponent<Image>().color = Color.green;      
            }
            else
            {
                m_reticle.GetComponent<Image>().color = Color.red;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            if (Input.GetMouseButtonDown(0) && other.gameObject.GetComponent<Interactable>().CanInteract())
            {
                other.gameObject.GetComponent<Interactable>().Interact();

                if(!other.gameObject.GetComponent<Interactable>().CanInteract())
                {
                    m_reticle.GetComponent<Image>().color = Color.red;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            m_reticle.GetComponent<Image>().color = Color.white;
        }
    }
}
