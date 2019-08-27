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

    public static DialogDetail ConversionFromXML(XmlNode node)
    {
        DialogDetail dialog = new DialogDetail();
        dialog.m_dialog = node.Attributes["text"].Value;
        return dialog;
    }
}

public class SelectionDetail
{
    public List<Selection> m_selections;
    public SelectionDetail()
    {
        m_selections = new List<Selection>();
    }

    public static SelectionDetail ConversionFromXML(XmlNode node)
    {
        SelectionDetail newSelectionDetail = new SelectionDetail();
        XmlNodeList selections = node.ChildNodes;
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
        return newSelectionDetail;
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
    public List<ActionNode> m_actions;
    public DialogCollection()
    {
        m_actions = new List<ActionNode>();
    }
}

public class ActionNode
{
    public string m_Type;
    public XmlNode m_Detail;

    public ActionNode()
    {
        m_Type = "";
        m_Detail = null;
    }
    public ActionNode(string type, XmlNode detail)
    {
        m_Type = type;
        m_Detail = detail;
    }
}

public class DialogManager 
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
                newDialogCollection.m_actions.Add(new ActionNode(dialogList[dialogID].Name, dialogList[dialogID]));
            }
            m_dialogCollections.Add(int.Parse(nodes[i].Attributes["id"].Value), newDialogCollection);
        }
    }

    public int GetNextDialog(out DialogDetail dialog, out SelectionDetail selection)
    {
        dialog = null;
        selection = null;
        if (m_currentCollection != null && m_currentCollection.m_actions != null &&
            m_currentCollectionDialogID < m_currentCollection.m_actions.Count)
        {
            ActionNode action = m_currentCollection.m_actions[m_currentCollectionDialogID];
            m_currentCollectionDialogID++;
            switch (action.m_Type)
            {
                case "dialog":
                    dialog = DialogDetail.ConversionFromXML(action.m_Detail);
                    return 0;
                case "selection":
                    selection = SelectionDetail.ConversionFromXML(action.m_Detail);
                    return 1;
            }
        }
       
        return -1;
    }
    public void GetCollection(int collectionID)
    {
        m_currentCollectionID = collectionID;
        m_currentCollection = m_dialogCollections[collectionID];
        m_currentCollectionDialogID = 0;
        m_finishSelection = false; 
    }
}
