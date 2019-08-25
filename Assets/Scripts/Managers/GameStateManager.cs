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
        GuiManager.Instance.IdentityGuiDemonstration();
    }

    public void BackToPlaying()
    {
        ResumeGame();
        Debug.Log("[GameStateManager] On Mirror, Change Identity");
        GuiManager.Instance.PlayingGuiDemonstration();
    }

}
