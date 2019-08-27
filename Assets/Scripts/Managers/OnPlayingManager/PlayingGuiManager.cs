using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayingGuiManager : MonoBehaviour
{
    public Sprite m_FemaleSprite;
    public Sprite m_MaleSprite;
    public Image m_Identity;

    // Start is called before the first frame update
    void OnEnable()
    {
        switch (DataManager.Instance.GetIdentityID())
        {
            case 1:
                m_Identity.sprite = m_FemaleSprite;
                break;
            case 2:
                m_Identity.sprite = m_MaleSprite;
                break;
        }
    }
}
