using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DataManager : Singleton<DataManager>
{
    private DialogManager m_dialog;
    private PlayerStatus m_playerStatus;

    // Start is called before the first frame update
    DataManager()
    {
        m_playerStatus = new PlayerStatus(1);
        m_dialog = new DialogManager();
    }

    private void Awake()
    {
        m_dialog.Load("Assets/Resources/Data/dialog_test.xml");
    }

    public void GetCollection(string collectionID)
    {
        m_dialog.GetCollection(collectionID);
    }

    public ActionType GetNextDialog(out DialogDetail dialog, out SelectionDetail selection)
    {
        return m_dialog.GetNextDialog(out dialog, out selection);
    }

    public ActionType GetCurrentDialog(out DialogDetail dialog, out SelectionDetail selection)
    {
        return m_dialog.GetCurrentDialog(out dialog, out selection);
    }

    public void ChangeIdentity(int identityID)
    {
        m_playerStatus.m_IdentityID = identityID;
    }

    public int GetIdentityID()
    {
        return m_playerStatus.m_IdentityID;
    }

    public Vector3 CurrentPlayerPosition
    {
        get {
            return m_playerStatus.m_Position;
        }
    }

    public bool IsPlayerHide()
    {
        return m_playerStatus.m_IsHide;
    }

    public void ChangePlayerHideStatus(bool hide)
    {
        m_playerStatus.m_IsHide = hide;
    }

    public void UpdatePlayerPosition(Vector3 updatePosition)
    {
        m_playerStatus.m_Position = updatePosition;
    }

    public bool IsDayTime()
    {
        return m_playerStatus.m_Time == 0;
    }

    public void ToggleTime()
    {
        m_playerStatus.m_Time = 1 - m_playerStatus.m_Time;
    }
}
