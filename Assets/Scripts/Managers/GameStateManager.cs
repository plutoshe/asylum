using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private static GameStateManager m_instance;
    private bool m_isPaused = false;

    public static GameStateManager _instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new GameObject("GameStateManager").AddComponent<GameStateManager>();
            }

            return m_instance;
        }
    }

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
}
