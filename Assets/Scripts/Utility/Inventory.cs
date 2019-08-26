using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    private GameObject[] m_itemList;
    private GameObject m_item;
    private bool m_isExaminig;
    private Vector3 m_originPos;
    private Quaternion m_originRot;
    private GameObject m_player;

    private float YOFFSET = .25f;
    private float ROTSPEED = 3;
    private float DISTANCE = .75f;
    private Vector3 MENUPOS;
    private Quaternion MENUROT = new Quaternion(0,0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        m_itemList = new GameObject[4];
        m_isExaminig = false;
        m_player = GameObject.Find("Player");
        MENUPOS = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z-10);
    }

    // Update is called once per frame
    void Update()
    {
        InventoryInput();
        RotateItem();
    }

    private void InventoryInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !m_isExaminig && m_itemList[0] != null)
        {
            InitilizeExamine();
            m_item = m_itemList[0];
            m_item.transform.rotation = Camera.main.transform.rotation;
            m_item.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !m_isExaminig && m_itemList[1] != null)
        {
            InitilizeExamine();
            m_item = m_itemList[1];
            m_item.transform.rotation = Camera.main.transform.rotation;
            m_item.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !m_isExaminig && m_itemList[2] != null)
        {
            InitilizeExamine();
            m_item = m_itemList[2];
            m_item.transform.rotation = Camera.main.transform.rotation;
            m_item.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && !m_isExaminig && m_itemList[3] != null)
        {
            InitilizeExamine();
            m_item = m_itemList[3];
            m_item.transform.rotation = Camera.main.transform.rotation;
            m_item.SetActive(true);
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
        m_originPos = m_player.transform.position;
        m_originRot = m_player.transform.rotation;
        m_player.GetComponent<Rigidbody>().useGravity = false;
        m_player.transform.position = MENUPOS;
        m_player.transform.rotation = MENUROT;
        Camera.main.transform.rotation = MENUROT;
        GameStateManager.Instance.ExamineItem();
    }

    private void EndExamine()
    {
        m_item.SetActive(false);
        m_isExaminig = false;
        m_player.transform.position = m_originPos;
        m_player.transform.rotation = m_originRot;
        m_player.GetComponent<Rigidbody>().useGravity = true;
        GameStateManager.Instance.DoneExaminig();
    }

    private void RotateItem()
    {
        if(m_isExaminig)
        {
            m_item.transform.Rotate(Input.GetAxis("Vertical")* ROTSPEED, 0.0f, 0.0f,Space.Self);
            m_item.transform.Rotate(0.0f,Input.GetAxis("Horizontal")* ROTSPEED, 0.0f, Space.World);
        }
    }

    public bool PlaceItemInInventory(GameObject item)
    {        
        for(int i = 0; i < m_itemList.Length; i++)
        {
            if(m_itemList[i] == null)
            {
                item.transform.position = new Vector3(MENUPOS.x, MENUPOS.y + YOFFSET, MENUPOS.z + DISTANCE);
                item.SetActive(false);
                m_itemList[i] = item;
                return true;
            }
        }
        return false;
    }
}
