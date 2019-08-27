﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public GameObject IdentityGui;
    public GameObject PlayingGui;
    public GameObject DialogGui;
    public void OnEnable()
    {
        CustomEventManager.Instance.StartListening(GuiEventConstant.s_DialogDemonstration, OpenDialog);
        CustomEventManager.Instance.StartListening(GuiEventConstant.s_DialogClose, CloseDialog);
        CustomEventManager.Instance.StartListening(GuiEventConstant.s_PlayerPlaying, PlayingGuiDemonstration);
        CustomEventManager.Instance.StartListening(GuiEventConstant.s_IdentityChange, IdentityGuiDemonstration);
    }

    public void OnDisable()
    {
        CustomEventManager.Instance.StopListening(GuiEventConstant.s_DialogDemonstration, OpenDialog);
        CustomEventManager.Instance.StopListening(GuiEventConstant.s_DialogClose, CloseDialog);
        CustomEventManager.Instance.StopListening(GuiEventConstant.s_PlayerPlaying, PlayingGuiDemonstration);
        CustomEventManager.Instance.StopListening(GuiEventConstant.s_IdentityChange, IdentityGuiDemonstration);
    }

    public void IdentityGuiDemonstration()
    {
        DialogGui.SetActive(false);
        PlayingGui.SetActive(false);
        IdentityGui.SetActive(true);
    }

    public void PlayingGuiDemonstration()
    {
        DialogGui.SetActive(false);
        PlayingGui.SetActive(true);
        IdentityGui.SetActive(false);
    }

    public void CloseExamineGui()
    {
        DialogGui.SetActive(false);
        PlayingGui.SetActive(true);
        IdentityGui.SetActive(false);
    }

    public void OpenExamineGui()
    {
        DialogGui.SetActive(false);
        PlayingGui.SetActive(false);
        IdentityGui.SetActive(false);
    }

    public void OpenDialog()
    {
        DialogGui.SetActive(true);
        PlayingGui.SetActive(false);
        IdentityGui.SetActive(false);
    }

    public void CloseDialog()
    {
        DialogGui.SetActive(false);
        IdentityGui.SetActive(false);
        PlayingGui.SetActive(true);
    }
}
