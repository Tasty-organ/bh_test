using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bool isCursorVisible = Cursor.visible;
            Cursor.lockState = isCursorVisible ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isCursorVisible;
        }
    }
}
