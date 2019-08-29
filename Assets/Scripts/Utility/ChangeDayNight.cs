using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDayNight : MonoBehaviour
{
    // Start is called before the first frame update

    public Material m_sky;
    private float m_exposure = 1.33f;

    private void OnEnable()
    {
        RenderSettings.skybox = m_sky;
        CustomEventManager.Instance.StartListening(CustomEventConstant.s_ToDayTime, ToDayTime);
        CustomEventManager.Instance.StartListening(CustomEventConstant.s_ToNight, ToNight);
    }

    private void OnDisable()
    {
        CustomEventManager.Instance.StopListening(CustomEventConstant.s_ToDayTime, ToDayTime);
        CustomEventManager.Instance.StopListening(CustomEventConstant.s_ToNight, ToNight);
    }

    public void ToNight()
    {
        m_exposure = 0.2f;
        RenderSettings.skybox.SetFloat("_Exposure", m_exposure);
    }

    public void ToDayTime()
    {
        m_exposure = 1.333f;
        RenderSettings.skybox.SetFloat("_Exposure", m_exposure);
    }

    public void GettingDark()
    {
        if(m_exposure > 0)
        {
            m_exposure -= 0.1f;
            RenderSettings.skybox.SetFloat("_Exposure", m_exposure);
        }
    }

    public void GettingLight()
    {
        if (m_exposure < 1.33f)
        {
            m_exposure += 0.1f;
            RenderSettings.skybox.SetFloat("_Exposure", m_exposure);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToNight();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ToDayTime();
        }
    }
}
