using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityStandardAssets.CrossPlatformInput; // auto edw mphke meta

public class CameraFreeLookController : MonoBehaviour {

    public CinemachineFreeLook freelookcam;
    private float h;
    private float v;
   

    //CinemachineOrbitalTransposer.AxisState xAxis;
    void Update () {

        h = Input.GetAxis("Mouse X");
        v = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(1))
        {

            freelookcam.m_XAxis.m_InputAxisValue = h;
            freelookcam.m_YAxis.m_InputAxisValue = v;
            
            freelookcam.m_YAxis.m_InvertAxis = true;
        }
        else if (!Input.GetMouseButton(1))
        {
            freelookcam.m_XAxis.m_InputAxisValue = 0;
            freelookcam.m_YAxis.m_InputAxisValue = 0;
        }
        if (Input.GetMouseButtonDown(1))
        {

            Cursor.visible = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.visible = true;
        }
        
    }
    
    
}
