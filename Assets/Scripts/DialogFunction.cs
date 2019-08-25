using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogFunction : MonoBehaviour
{
    public Sprite m_CharacterNormal;
    public Sprite m_CharacterScared;
    public Sprite m_CharacterShout;
    public Text m_Dialog;
    DialogDetail m_GameDialog;
    SelectionDetail m_GameSelections;

    void Start()
    {
        m_Dialog.text = "";
    }

    void UpdateDialog()
    {
        int itemType = DataManager.Instance.dialog.GetNextDialog(out m_GameDialog, out m_GameSelections);
        switch (itemType)
        {
            case -1: m_Dialog.text = ""; break;
            case 0: m_Dialog.text = m_GameDialog.m_dialog; break;
            case 1: m_Dialog.text = "it is a selection"; break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UpdateDialog();

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DataManager.Instance.dialog.GetCollection(3);
            UpdateDialog();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DataManager.Instance.dialog.GetCollection(1);
            UpdateDialog();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DataManager.Instance.dialog.GetCollection(2);
            UpdateDialog();
        }
    }
}
