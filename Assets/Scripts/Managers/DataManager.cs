using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DataManager : Singleton<DataManager>
{
    public DialogManager m_dialog;

    // Start is called before the first frame update
    DataManager()
    {
        m_dialog = new DialogManager();
    }

    private void Awake()
    {
        m_dialog.Load("Assets/Resources/Data/dialog_test.xml");
    }

    public void GetCollection(int collectionID)
    {
        m_dialog.GetCollection(collectionID);
    }

    public int GetNextDialog(out DialogDetail dialog, out SelectionDetail selection)
    {
        return m_dialog.GetNextDialog(out dialog, out selection);
    }
}
