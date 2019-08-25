using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int m_IdentityID;
    public PlayerStatus(int identityID)
    {
        m_IdentityID = identityID;
    }
}
