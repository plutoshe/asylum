using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyShining : MonoBehaviour
{
    public Sprite m_NewKey;
    public Sprite m_GlowKey;
    public Material m_ShiningEffect;
    private void OnEnable()
    {
        CustomEventManager.Instance.StartListening(CustomEventConstant.s_ToNight, nightChange);
    }

    private void OnDisable()
    {
        CustomEventManager.Instance.StopListening(CustomEventConstant.s_ToNight, nightChange);
    }

    private void nightChange()
    {
        var collectableItem = GetComponent<Collectible>();
        GetComponent<SpriteRenderer>().sprite = m_NewKey;
        m_ShiningEffect.SetTexture("_MainTex", m_NewKey.texture);
        m_ShiningEffect.SetTexture("_GlowTex", m_GlowKey.texture);
        //GetComponent<SpriteRenderer>().material = m_ShiningEffect;
        collectableItem.SetImage(m_NewKey);

        Inventory.Instance.ChangeSlotImage(collectableItem.GetSlot(), m_NewKey, m_ShiningEffect);
    }
}
