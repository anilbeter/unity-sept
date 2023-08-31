using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    // Since this is a simple project, will be use simple input solution
    public int directionX = 0;

    void Update()
    {
        if (Keyboard.current.dKey.isPressed)
            directionX = 1;
        else if (Keyboard.current.aKey.isPressed)
            directionX = -1;
        else
            directionX = 0;
        if (Keyboard.current.escapeKey.isPressed)
            Application.Quit();
    }
}
