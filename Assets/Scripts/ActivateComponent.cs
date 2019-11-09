using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateComponent : MonoBehaviour
{
    public bool isActive = false;

    public void SetState(bool state)
    {
        isActive = state;
    }

    public bool GetState()
    {
        return isActive;
    }
}
