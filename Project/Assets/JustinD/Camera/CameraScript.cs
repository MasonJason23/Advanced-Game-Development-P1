using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraScript : MonoBehaviour
{
    //public CinemachineVirtualCamera vcam;
    public CinemachineFreeLook testMachine;
    
    void Update()
    {
        // if left shift is held the camera can be moved
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log(testMachine.m_YAxis.m_InputAxisName);
            testMachine.m_YAxis.m_InputAxisName = ("Mouse Y");
            testMachine.m_XAxis.m_InputAxisName = ("Mouse X");
        }
        
        // sets axis inputs to nothing
        else
        {
            testMachine.m_YAxis.m_InputAxisName = string.Empty;
            testMachine.m_XAxis.m_InputAxisName = string.Empty;
        }
    }
}
