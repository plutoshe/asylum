using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Collectible
{
    private int m_uses = 0;
    public virtual void Consume()
    {

    }

    public bool CanConsume()
    {
       if(m_uses > 0)
        {
            return true;
        }
       else
        {
            return false;
        }
    }

    public void SetUses(int quantity)
    {
        m_uses =  quantity;
    }

    public void Use()
    {
        m_uses--;

        if(m_uses <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Gain(int quantity)
    {
        m_uses += quantity;
    }
}
