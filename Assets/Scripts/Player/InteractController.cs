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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            m_reticle.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            if (Input.GetMouseButtonDown(0) && other.gameObject.GetComponent<Interactable>().CanInteract())
            {
                other.gameObject.GetComponent<Interactable>().Interact();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            m_reticle.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        }
    }
}
