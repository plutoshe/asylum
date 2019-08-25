using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractController : MonoBehaviour
{

    public Image m_reticle;

    //removes the mouse and locks the mouse onto the game screen
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null && !GameStateManager._instance.IsPaused())
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
        if (other.gameObject.GetComponent<Interactable>() != null && !GameStateManager._instance.IsPaused())
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
        if (other.gameObject.GetComponent<Interactable>() != null && !GameStateManager._instance.IsPaused())
        {
            m_reticle.GetComponent<Image>().color = Color.white;
        }
    }

    void Update()
    {
        if(GameStateManager._instance.IsPaused())
        {
            m_reticle.gameObject.SetActive(false);
        }
        else
        {
            m_reticle.gameObject.SetActive(true);
        }
    }
}
