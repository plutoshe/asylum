using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    private bool m_isPaused = false;
    private Vector3 m_oldCameraPosition;
    private Quaternion m_oldCameraRotation;
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
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.s_IdentityChange);
    }

    public void BackToPlaying()
    {
        ResumeGame();
        Debug.Log("[GameStateManager] On Mirror, Change Identity");
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.s_PlayerPlaying);
    }

    public void ExamineItem()
    {
        PauseGame();
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.s_OpenExamine);
    }

    public void DoneExaminig()
    {
        ResumeGame();
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.s_CloseExamine);
    }

    public void ShowDialog(string collectionID, Camera viewCamera)
    {
        PauseGame();
        m_oldCameraPosition = Camera.main.transform.position;
        m_oldCameraRotation = Camera.main.transform.rotation;
        Camera.main.transform.position = viewCamera.transform.position;
        Camera.main.transform.rotation = viewCamera.transform.rotation;
        DataManager.Instance.GetCollection(collectionID);
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.s_DialogDemonstration);
    }

    public void DoneDialog()
    {
        Camera.main.transform.position = m_oldCameraPosition;
        Camera.main.transform.rotation = m_oldCameraRotation;
        CustomEventManager.Instance.TriggerEvent(GuiEventConstant.s_DialogClose);
        ResumeGame();
    }

    public void ChangeToNight()
    {
        DataManager.Instance.ToggleTime();
        CustomEventManager.Instance.TriggerEvent(CustomEventConstant.s_ToNight);
    }

    public void ChangeToDayTime()
    {
        DataManager.Instance.ToggleTime();
        CustomEventManager.Instance.TriggerEvent(CustomEventConstant.s_ToDayTime);
    }

    public void HideUnderBed()
    {
        PauseGame();
        DataManager.Instance.ChangePlayerHideStatus(true);
    }

    public void GetOutOfBed()
    {
        ResumeGame();
        DataManager.Instance.ChangePlayerHideStatus(false);
    }

    public void GameOver()
    {
        PauseGame();
        print("GameOver");
    }

}
