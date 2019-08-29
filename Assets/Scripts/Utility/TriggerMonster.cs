using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonster : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        CustomEventManager.Instance.TriggerEvent(CustomEventConstant.s_ShowMonster);
    }
}
