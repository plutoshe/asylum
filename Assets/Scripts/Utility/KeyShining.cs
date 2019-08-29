using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyShining : MonoBehaviour
{
    public Sprite m_NewKey;
    public Sprite m_GlowKey;
    public Material m_ShiningEffect;
    private bool m_isShining;

    private void Awake()
    {
        m_isShining = false;
        CustomEventManager.Instance.StartListening(CustomEventConstant.s_ToNight, nightChange);
    }

    private void OnDestroy()
    {
        CustomEventManager.Instance.StopListening(CustomEventConstant.s_ToNight, nightChange);
    }

    private void OnDisable()
    {
        var collectableItem = GetComponent<Collectible>();
        if (collectableItem.m_hasBeenInspected && m_isShining)
        {
            Inventory.Instance.ChangeSlotImage(collectableItem.GetSlot(), m_NewKey, null);
        }
    }

    private void StartShining()
    {
        var collectableItem = GetComponent<Collectible>();
        GetComponent<SpriteRenderer>().sprite = m_NewKey;
        m_ShiningEffect.SetTexture("_MainTex", m_NewKey.texture);
        m_ShiningEffect.SetTexture("_GlowTex", m_GlowKey.texture);
        //GetComponent<SpriteRenderer>().material = m_ShiningEffect;
        collectableItem.SetImage(m_NewKey);
        m_isShining = true;

        Inventory.Instance.ChangeSlotImage(collectableItem.GetSlot(), m_NewKey, m_ShiningEffect);
    }

    private void nightChange()
    {
        StartShining();
    }
}
