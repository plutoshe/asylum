using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdentityManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image m_Identity01;
    public Animator m_FemaleGlow;
    public Animator m_FemaleShow;
    public Image m_Identity02;
    public Animator m_MaleShow;

    public Text m_GameText;
    private int m_IdentityNum;
    void Start()
    {
        m_FemaleGlow.gameObject.SetActive(false);

        m_FemaleGlow.SetBool("GlowStart", false);
        m_FemaleShow.SetBool("Show", false);
        m_MaleShow.SetBool("Show", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_FemaleGlow.gameObject.SetActive(true);

            m_FemaleGlow.SetBool("GlowStart", true);
            m_FemaleShow.SetBool("Show", true);
            m_MaleShow.SetBool("Show", false);
            m_IdentityNum = 1;

        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_FemaleGlow.gameObject.SetActive(false);

            m_FemaleGlow.SetBool("GlowStart", false);
            m_FemaleShow.SetBool("Show", false);
            m_MaleShow.SetBool("Show", true);

            m_IdentityNum = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if(m_IdentityNum == 1)
            {
                m_GameText.text = "Female Character has been selected.";
            }
            else if(m_IdentityNum == 2)
            {
                m_GameText.text = "Male Character has been selected.";
            }


        }
    }
}
