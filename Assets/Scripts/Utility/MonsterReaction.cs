using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterReaction : MonoBehaviour
{
    public float m_SenseDistance;
    public float m_stayChasingTime;
    public float m_speed;
    public Transform m_waitPoint;
    private Vector3 m_waitPosition;
    private Vector3 m_onGoingChasingPosition;
    private float m_timeLostInSight;

    private void Awake()
    {
        m_timeLostInSight = m_stayChasingTime;
        m_waitPosition = m_waitPoint.position;
    }

    bool NoColliderAtPath(Vector3 toPosition, Vector3 originPosition)
    {
        toPosition.y += 1f;
        originPosition.y += 1f;
        RaycastHit hit;
        Ray ray = new Ray(originPosition, toPosition - originPosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    return true;
                }
            }
        }
        return false;
        //return Physics.Raycast(originPosition, toPosition, Vector3.Distance(toPosition, originPosition));       
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStateManager.Instance.IsPaused())
        {
            m_timeLostInSight += Time.deltaTime;
            if (!DataManager.Instance.IsPlayerHide() && Vector3.Distance(DataManager.Instance.CurrentPlayerPosition, transform.position) <= m_SenseDistance)
            {
                if (Vector3.Distance(DataManager.Instance.CurrentPlayerPosition, transform.position) < .5f)
                {
                    GameStateManager.Instance.GameOver();
                }
                if (NoColliderAtPath(DataManager.Instance.CurrentPlayerPosition, transform.position))
                {
                    m_timeLostInSight = 0;
                    m_onGoingChasingPosition = DataManager.Instance.CurrentPlayerPosition;
                    transform.LookAt(DataManager.Instance.CurrentPlayerPosition);
                    Vector3 oldRoration = transform.rotation.eulerAngles;
                    transform.rotation = Quaternion.Euler(90, oldRoration.y, oldRoration.z);


                }
            }
            if (m_timeLostInSight < m_stayChasingTime)
            {
                transform.position += m_speed * (Time.deltaTime / 1) * (m_onGoingChasingPosition - transform.position).normalized;
            }
            else
            {
                transform.position += m_speed * (Time.deltaTime / 1) * (m_waitPosition - transform.position).normalized;
            }
        }
    }
}
