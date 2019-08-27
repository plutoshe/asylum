using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteraction : Interactable
{
    public override void Interact()
    {
        if (DataManager.Instance.IsDayTime())
        {
            GameStateManager.Instance.ChangeToNight();
        }
        else
        {
            GameStateManager.Instance.ChangeToDayTime();
        }
    }
}

