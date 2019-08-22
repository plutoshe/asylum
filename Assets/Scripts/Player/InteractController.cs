using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            if (Input.GetMouseButtonDown(0) && other.gameObject.GetComponent<Interactable>().CanInteract())
            {
                other.gameObject.GetComponent<Interactable>().Interact();
            }
        }
    }
}
