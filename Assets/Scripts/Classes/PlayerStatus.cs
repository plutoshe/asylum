using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{ 
    public int m_IdentityID;
    public int m_Time;
    public Vector3 m_Position;
    public bool m_IsHide;
    public PlayerStatus(int identityID)
    {
        m_IdentityID = identityID;
        m_Time = 0;
        m_IsHide = false;
    }
}
