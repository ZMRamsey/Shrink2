using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    bool isPressed;
    public ActivateComponent activate;

    public bool GetState()
    {
        return isPressed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isPressed = true;
        activate.SetState(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        isPressed = false;
        activate.SetState(false);
    }
}
