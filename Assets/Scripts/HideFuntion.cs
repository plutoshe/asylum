using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFuntion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_MainCam;
    public GameObject m_HideCam;
    public Animator m_MonsterMove;


    void Start()
    {
        m_MainCam.SetActive(true);
        m_HideCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_MainCam.SetActive(false);
            m_HideCam.SetActive(true);
            m_MonsterMove.SetBool("MonsterMoveStart", true);
            
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_MainCam.SetActive(true);
            m_HideCam.SetActive(false);
            m_MonsterMove.SetBool("MonsterMoveStart", false);
        }
    }

  
}
