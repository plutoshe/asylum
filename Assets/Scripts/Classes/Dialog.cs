using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DialogDetail
{
    public string m_dialog;
    public int m_animationID;
    public Sprite m_characterImage;
    public DialogDetail()
    { }
}

public class SelectionDetail
{
    public List<Selection> m_selections;
    public SelectionDetail()
    {
        m_selections = new List<Selection>();
    }
}

public class Selection
{
    public string m_text;
    public int m_collectionID;
    public Selection()
    {
        m_text = "";
        m_collectionID = 0;
    }
    public Selection(string text, int collectionID)
    {
        m_text = text;
        m_collectionID = collectionID;
    }
}

public class DialogCollection
{
    public List<DialogDetail> m_dialogs;
    public SelectionDetail m_finalSelection;
    public DialogCollection()
    {
        m_dialogs = new List<DialogDetail>();
    }
}

public interface DialogInterface
{
    int GetPlayerNextDialog(out DialogDetail dialog, out SelectionDetail selection);
    void UpdatePlayerSelection(int collectionID);
}

public class DialogManager : DialogInterface
{
    private Dictionary<int, DialogCollection> m_dialogCollections;
    private int m_currentCollectionID = -1;
    private DialogCollection m_currentCollection = null;
    private int m_currentCollectionDialogID = -1;
    private bool m_finishSelection = false;
    public DialogManager()
    {
        m_dialogCollections = new Dictionary<int, DialogCollection>();
    }
    public void Load(string xmlFileName)
    {

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(xmlFileName);

        XmlNodeList nodes = xmlDoc.GetElementsByTagName("flow")[0].ChildNodes;
        for (int i = 0; i < nodes.Count; i++)
        {
            DialogCollection newDialogCollection = new DialogCollection();
            XmlNodeList dialogList = nodes[i].ChildNodes;
            for (int dialogID = 0; dialogID < dialogList.Count; dialogID++)
            {
                switch (dialogList[dialogID].Name)
                {
                    case "dialog":
                        DialogDetail newDialogDetail = new DialogDetail();
                        newDialogDetail.m_dialog = dialogList[dialogID].Attributes["text"].Value;
                        newDialogCollection.m_dialogs.Add(newDialogDetail);
                        break;
                    case "selection":
                        SelectionDetail newSelectionDetail = new SelectionDetail();
                        XmlNodeList selections = dialogList[dialogID].ChildNodes;
                        for (int selectionID = 0; selectionID < selections.Count; selectionID++)
                        {
                            if (selections[selectionID].Name == "item")
                            {
                                newSelectionDetail.m_selections.Add(
                                    new Selection(
                                        selections[selectionID].Attributes["text"].Value,
                                        int.Parse(selections[selectionID].Attributes["id"].Value)
                                    )
                                );
                            }
                        }
                        newDialogCollection.m_finalSelection = newSelectionDetail;
                        break;
                }
            }
            m_dialogCollections.Add(int.Parse(nodes[i].Attributes["id"].Value), newDialogCollection);
        }
    }

    public int GetPlayerNextDialog(out DialogDetail dialog, out SelectionDetail selection)
    {
        dialog = null;
        selection = null;
        if (m_currentCollection != null)
        {
            if (m_currentCollectionDialogID < m_currentCollection.m_dialogs.Count)
            {
                dialog = m_currentCollection.m_dialogs[m_currentCollectionDialogID];
                m_currentCollectionDialogID++;
                return 0;
            }
            else if (!m_finishSelection && m_currentCollection.m_finalSelection != null)
            {
                selection = m_currentCollection.m_finalSelection;
                m_finishSelection = true;
                return 1;

            }
        }
        return -1;
    }
    public void UpdatePlayerSelection(int collectionID)
    {
        if (m_currentCollectionID != collectionID)
        {
            m_currentCollectionID = collectionID;
            m_currentCollection = m_dialogCollections[collectionID];
            m_currentCollectionDialogID = 0;
            m_finishSelection = false;
        }
        else
        {
            m_currentCollectionDialogID++;
        }
        
    }
}
