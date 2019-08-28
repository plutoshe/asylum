using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFuntion : Interactable
{
    // Start is called before the first frame update
    private Vector3 m_oldCameraPosition;
    private Quaternion m_oldCameraRotation;
    public GameObject m_HideCam;
    public Animator m_MonsterMove;


    void Awake()
    {
        m_HideCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Camera.main.transform.position = m_oldCameraPosition;
            Camera.main.transform.rotation = m_oldCameraRotation;
            //m_MonsterMove.SetBool("MonsterMoveStart", false);
            GameStateManager.Instance.GetOutOfBed();
        }
    }

    public override void Interact()
    {
        m_oldCameraPosition = Camera.main.transform.position;
        m_oldCameraRotation = Camera.main.transform.rotation;
        Camera.main.transform.position = m_HideCam.transform.position;
        Camera.main.transform.rotation = m_HideCam.transform.rotation;
        //m_MonsterMove.SetBool("MonsterMoveStart", true);
        GameStateManager.Instance.HideUnderBed();
    }
}
