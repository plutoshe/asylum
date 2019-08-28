using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HideTextAndNoise : MonoBehaviour
{
    public Text m_hint;
    public Animator m_NoiseScreen;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ShowText()
    {
        m_hint.gameObject.SetActive(true);
    }
    public void HideText()
    {
        m_hint.gameObject.SetActive(false);
    }

    public void ShowNoiseScreen()
    {
        m_NoiseScreen.gameObject.SetActive(true);
        m_NoiseScreen.SetBool("NoiseScreenStart", true);
    }

    public void StopNoiseScreen()
    {
        m_NoiseScreen.SetBool("NoiseScreenStop", true);
    }
}
