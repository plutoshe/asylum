using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IdentityDialog
{ 
    public string m_collectionID;
    public int m_identityID;
}

public class CharacterInteraction : Interactable
{
    public List<IdentityDialog> m_collections;
    public Camera m_characterInteractionCamera;

    public override void Interact()
    {
        int identityID = DataManager.Instance.GetIdentityID();
        if (m_collections != null)
        {
            for (int i = 0; i < m_collections.Count; i++)
            {
                if (m_collections[i].m_identityID == identityID)
                {
                    GameStateManager.Instance.ShowDialog(m_collections[i].m_collectionID, m_characterInteractionCamera);
                }
            }
        }
    }
}
