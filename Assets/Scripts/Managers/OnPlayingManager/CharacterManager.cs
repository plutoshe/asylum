using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private List<Transform> m_dailyTimeCharacters;
    private List<Transform> m_nightCharacters;

    public bool HasString(string origin, string match)
    {
        return match.Contains(origin);
    }

    private void OnEnable()
    {
        bool isDayTime = DataManager.Instance.IsDayTime();
        if (isDayTime)
        {
            SetDayTime();
        } else
        {
            SetNight();
        }
        CustomEventManager.Instance.StartListening(CustomEventConstant.s_ToDayTime, SetDayTime);
        CustomEventManager.Instance.StartListening(CustomEventConstant.s_ToNight, SetNight);
    }

    private void OnDisable()
    {
        CustomEventManager.Instance.StopListening(CustomEventConstant.s_ToDayTime, SetDayTime);
        CustomEventManager.Instance.StopListening(CustomEventConstant.s_ToNight, SetNight);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < m_dailyTimeCharacters.Count; i++)
        {
            Destroy(m_dailyTimeCharacters[i]);
        }
        for (int i = 0; i < m_nightCharacters.Count; i++)
        {
            Destroy(m_nightCharacters[i]);
        }
        m_dailyTimeCharacters.Clear();
        m_nightCharacters.Clear();
    }

    private void Awake()
    {
        m_dailyTimeCharacters = transform.FindDeepChildren("Character", HasString);
        m_nightCharacters = transform.FindDeepChildren("Monster", HasString);
    }

    public void SetDayTime()
    {
        for (int i = 0; i < m_dailyTimeCharacters.Count; i++)
        {
            m_dailyTimeCharacters[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < m_nightCharacters.Count; i++)
        {
            m_nightCharacters[i].gameObject.SetActive(false);
        }
    }

    public void SetNight()
    {
        for (int i = 0; i < m_dailyTimeCharacters.Count; i++)
        {
            m_dailyTimeCharacters[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < m_nightCharacters.Count; i++)
        {
            m_nightCharacters[i].gameObject.SetActive(true);
        }
    }

}
