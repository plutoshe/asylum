using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMusicController : MonoBehaviour
{
    [SerializeField] AudioClip m_exitClip;
    [SerializeField] AudioClip m_enterClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MusicManager.Instance.ChangeBGMusic(m_enterClip);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MusicManager.Instance.ChangeBGMusic(m_exitClip);
        }     
    }
}
