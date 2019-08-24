using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private GameObject m_player;

    void Start()
    {
        m_player = GameObject.Find("Player");
    }
        
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(m_player.transform);
    }
}
