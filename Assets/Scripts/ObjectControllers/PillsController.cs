using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsController : Consumable
{
    // Start is called before the first frame update
    void Start()
    {
        SetUses(1);
    }

    public override void Consume()
    {
        Use();
    }
}
