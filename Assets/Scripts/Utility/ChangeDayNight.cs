using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDayNight : MonoBehaviour
{
    // Start is called before the first frame update

    public Material m_sky;
    private float m_exposure = 1.33f;
    void Start()
    {
        m_exposure = 1.33f;
        RenderSettings.skybox = m_sky;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) & m_exposure <1.33)
        {
            m_exposure += 0.1f;
            RenderSettings.skybox.SetFloat("_Exposure", m_exposure);
            //RenderSettings.skybox.
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) & m_exposure > 0)
        {
            m_exposure -= 0.1f;
            RenderSettings.skybox.SetFloat("_Exposure", m_exposure);
            //RenderSettings.skybox.
        }
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
}
