using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    private bool m_isPaused = false;
    
    public void PauseGame()
    {
        m_isPaused = true;
    }

    public void ResumeGame()
    {
        m_isPaused = false;
    }

    public bool IsPaused()
    {
        return m_isPaused;
    }

    public void ChangeIdentity()
    {
        PauseGame();
        Debug.Log("[GameStateManager] On Mirror, Change Identity");
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.IdentityChange);
    }

    public void BackToPlaying()
    {
        ResumeGame();
        Debug.Log("[GameStateManager] On Mirror, Change Identity");
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.PlayerPlaying);
    }

    public void ExamineItem()
    {
        PauseGame();
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.OpenExamine);
    }

    public void DoneExaminig()
    {
        ResumeGame();
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.CloseExamine);
    }

}
