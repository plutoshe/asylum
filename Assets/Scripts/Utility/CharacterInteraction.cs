using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : Interactable
{
    public int m_collectionID;
    public Camera m_characterInteractionCamera;

    public override void Interact()
    {
        GameStateManager.Instance.ShowDialog(m_collectionID, m_characterInteractionCamera);
    }
}
