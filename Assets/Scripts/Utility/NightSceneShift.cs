using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSceneShift : MonoBehaviour
{
    public GameObject Light;
    private void OnEnable()
    {
        CustomEventManager.Instance.StartListening(CustomEventConstant.s_ToNight, nightChange);
        Light.SetActive(false);
    }

    private void OnDisable()
    {
        CustomEventManager.Instance.StopListening(CustomEventConstant.s_ToNight, nightChange);
    }

    void nightChange()
    {
        Light.SetActive(true);
    }
}
