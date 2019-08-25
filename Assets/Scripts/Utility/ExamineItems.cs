using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineItems : MonoBehaviour
{
    [SerializeField] private GameObject[] m_itemList;
    private GameObject m_item;
    private bool m_isExaminig;
    private float DISTANCE = .75f;
    private Vector3 MENUPOS = new Vector3(500,500,500);
    private Quaternion MENUROT = new Quaternion(0,0,0,0);
    private Vector3 m_originPos;
    private Quaternion m_originRot;
    private GameObject m_player;
    [SerializeField] private float m_rotSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        m_isExaminig = false;
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ExamineInput();
        RotateItem();
    }

    private void ExamineInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !m_isExaminig)
        {
            InitilizeExamine();
           m_item = Instantiate(m_itemList[0], new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z) + Camera.main.transform.forward * DISTANCE, Camera.main.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !m_isExaminig)
        {
            InitilizeExamine();
            Debug.Log("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !m_isExaminig)
        {
            InitilizeExamine();
            Debug.Log("3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && !m_isExaminig)
        {
            InitilizeExamine();
            Debug.Log("4");
        }
        else if (Input.GetMouseButtonDown(0) && m_isExaminig && m_item.GetComponent<Consumable>() != null && m_item.GetComponent<Consumable>().CanConsume())
        {
            m_item.GetComponent<Consumable>().Use();
            m_item.GetComponent<Consumable>().Consume();

            if (!m_item.GetComponent<Consumable>().CanConsume())
            {
                EndExamine();
            }
        }
        else if (Input.GetMouseButtonDown(1) && m_isExaminig)
        {
            EndExamine();
        }
    }

    private void InitilizeExamine()
    {
        m_isExaminig = true;
        GameStateManager.Instance.PauseGame();
        m_originPos = m_player.transform.position;
        m_originRot = m_player.transform.rotation;
        m_player.GetComponent<Rigidbody>().useGravity = false;
        m_player.transform.position = MENUPOS;
        m_player.transform.rotation = MENUROT;
    }

    private void EndExamine()
    {
        Destroy(m_item);
        m_isExaminig = false;
        m_player.transform.position = m_originPos;
        m_player.transform.rotation = m_originRot;
        m_player.GetComponent<Rigidbody>().useGravity = true;
        GameStateManager.Instance.ResumeGame();
    }

    private void RotateItem()
    {
        if(m_isExaminig)
        {
            m_item.transform.Rotate(Input.GetAxis("Vertical")* m_rotSpeed, 0.0f, 0.0f,Space.Self);
            m_item.transform.Rotate(0.0f,Input.GetAxis("Horizontal")* m_rotSpeed, 0.0f, Space.World);
        }
    }
}
