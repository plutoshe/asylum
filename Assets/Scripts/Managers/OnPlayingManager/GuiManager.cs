using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public GameObject IdentityGui;
    public GameObject PlayingGui;

    public void OnEnable()
    {
        CustomEventManager.Instance.StartListening(GuiEventConstant.IdentityChange, IdentityGuiDemonstration);
        CustomEventManager.Instance.StartListening(GuiEventConstant.PlayerPlaying, PlayingGuiDemonstration);
    }

    public void OnDisable()
    {

    }

    public void IdentityGuiDemonstration()
    {
        PlayingGui.SetActive(false);
        IdentityGui.SetActive(true);
    }

    public void PlayingGuiDemonstration()
    {
        PlayingGui.SetActive(true);
        IdentityGui.SetActive(false);
    }

    public void CloseExamineGui()
    {
        PlayingGui.SetActive(true);
        IdentityGui.SetActive(false);
    }

    public void OpenExamineGui()
    {
        PlayingGui.SetActive(false);
        IdentityGui.SetActive(false);
    }
}
