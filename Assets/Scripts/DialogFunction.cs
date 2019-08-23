using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogFunction : MonoBehaviour
{
    public Sprite CharacterNormal;
    public Sprite CharacterScared;
    public Sprite CharacterShout;
    public Text Dialog;
    DialogDetail m_GameDialog;
    SelectionDetail m_GameSelections;

    void Start()
    {
        Dialog.text = "";
    }

    void UpdateDialog()
    {
        int itemType = DataManager.Instance.dialog.GetNextDialog(out m_GameDialog, out m_GameSelections);
        switch (itemType)
        {
            case -1: Dialog.text = ""; break;
            case 0: Dialog.text = m_GameDialog.m_dialog; break;
            case 1: Dialog.text = "it is a selection"; break;

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
