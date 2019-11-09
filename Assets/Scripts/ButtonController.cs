using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;
    // Start is called before the first frame update
    public bool GetState()
    {
        return isPressed;
    }

    public void SetState()
    {
        if (isPressed)
        {
            isPressed = false;
        }
        else
        {
            isPressed = true;
        }
        Debug.Log(isPressed);
    }
}
    
