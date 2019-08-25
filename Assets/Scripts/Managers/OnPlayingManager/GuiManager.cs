using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManager : Singleton<GuiManager>
{
    public GameObject IdentityGui;
    public GameObject PlayingGui;

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
}
