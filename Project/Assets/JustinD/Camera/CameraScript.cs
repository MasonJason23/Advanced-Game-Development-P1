using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    //public CinemachineVirtualCamera vcam;
    public CinemachineFreeLook testMachine;

    // Keep track when leftAlt is pressed
    private bool leftAltPressed = false;
    
    // Keep track when game ends
    private bool gameEnd = false;

    private void Start()
    {
        // Cursor is not visible and confined upon game start
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        // Giving Cinemachine freelook camera access to the mouse
        testMachine.m_YAxis.m_InputAxisName = ("Mouse Y");
        testMachine.m_XAxis.m_InputAxisName = ("Mouse X");
    }

    private void Update()
    {
        if (gameEnd) return;
        
        // Game ends, therefore the cursor should be visible for the player to interact with the GameOver Screen
        if (GameManager.GmInstance.state == GamePhase.END)
        {
            // Cursor is not visible
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            gameEnd = true;
        }
        
        // if left alt is held the camera can be moved
        if (Input.GetKey(KeyCode.LeftAlt) && leftAltPressed == false)
        {
            // Left Alt is being pressed
            leftAltPressed = true;

            // Cursor is not visible
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            // Set camera to empty
            testMachine.m_YAxis.m_InputAxisName = string.Empty;
            testMachine.m_XAxis.m_InputAxisName = string.Empty;
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            // Set cursor back to default
            leftAltPressed = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
            
            // Giving Cinemachine freelook camera access to the mouse
            testMachine.m_YAxis.m_InputAxisName = ("Mouse Y");
            testMachine.m_XAxis.m_InputAxisName = ("Mouse X");
        }
    }
}
