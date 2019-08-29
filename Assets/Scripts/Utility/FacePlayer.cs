using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private GameObject m_player;
    public Vector3 FixedOriginRotation;
    private Vector3 InitialEulerAngle;

    private void Awake()
    {
        InitialEulerAngle = transform.rotation.eulerAngles;
    }

    void Start()
    {
        m_player = GameObject.Find("Player");
    }
        
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(m_player.transform);
        Vector3 newEuler = gameObject.transform.rotation.eulerAngles;
        for (int i = 0; i < 3; i++)
        {
            if (FixedOriginRotation[i] != 0)
            {
                newEuler[i] = InitialEulerAngle[i];
            }
        }
        gameObject.transform.rotation = Quaternion.Euler(newEuler);
    }
}
