using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMouse : MonoBehaviour
{
    public Control cur;
    public enum Control
    {
        locked = 0,
        unlocked = 1
    }

    private void Update()
    {
        switch (cur)
        {
            case Control.locked:
                Cursor.lockState = CursorLockMode.Locked;
                break;
            case Control.unlocked:
                Cursor.lockState = CursorLockMode.Confined;
                break;
            default:
                cur = 0;
                break;
        }
    }
}
