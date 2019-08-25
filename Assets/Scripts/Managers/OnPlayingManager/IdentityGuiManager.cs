using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentityGuiManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image m_Identity01;
    public Animator m_FemaleGlow;
    public Animator m_FemaleShow;
    public Image m_Identity02;
    public Animator m_MaleShow;

    private int m_IdentityNum;
    void SelectFemaleEffect()
    {
        m_FemaleGlow.gameObject.SetActive(true);

        m_FemaleGlow.SetBool("GlowStart", true);
        m_FemaleShow.SetBool("Show", true);
        m_MaleShow.SetBool("Show", false);
    }

    void SelectMaleEffect()
    {
        m_FemaleGlow.gameObject.SetActive(false);

        m_FemaleGlow.SetBool("GlowStart", false);
        m_FemaleShow.SetBool("Show", false);
        m_MaleShow.SetBool("Show", true);
    }

    private void OnEnable()
    {
        switch (DataManager.Instance.GetIdentityID())
        {
            case 1:
                SelectFemaleEffect();
                break;
            case 2:
                SelectMaleEffect();
                break;
        }
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectFemaleEffect();
            DataManager.Instance.ChangeIdentity(1);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectMaleEffect();
            DataManager.Instance.ChangeIdentity(2);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            GameStateManager.Instance.BackToPlaying();
        }
    }
    
}
