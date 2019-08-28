using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogGuiManager : MonoBehaviour
{
    public Text m_Dialog;
    private DialogDetail m_GameDialog;
    private SelectionDetail m_GameSelections;

    private void OnEnable()
    {
        ActionType itemType = DataManager.Instance.GetCurrentDialog(out m_GameDialog, out m_GameSelections);
        UpdateUI(itemType);
    }

    private void UpdateUI(ActionType itemType)
    {
        switch (itemType)
        {
            case ActionType.None: GameStateManager.Instance.DoneDialog(); break;
            case ActionType.Dialog: m_Dialog.text = m_GameDialog.m_dialog; break;
            case ActionType.Selection: m_Dialog.text = "it is a selection"; break;

        }
    }

    private void UpdateDialog()
    {
        ActionType itemType = DataManager.Instance.GetNextDialog(out m_GameDialog, out m_GameSelections);
        UpdateUI(itemType);
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
            DataManager.Instance.GetCollection("3");
            UpdateDialog();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DataManager.Instance.GetCollection("1");
            UpdateDialog();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DataManager.Instance.GetCollection("2");
            UpdateDialog();
        }
    }
}
