using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    bool isPressed;

    public bool GetState()
    {
        return isPressed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isPressed = true;
        Debug.Log("PRESSED");
    }

    private void OnCollisionExit(Collision collision)
    {
        isPressed = false;
    }
}
