using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCameraPerspective : MonoBehaviour {

    public Camera_Change camera_Change;

    public void CameraToggle2D(bool toggle)
    {
        if (toggle == true)
        {
            camera_Change.GoTo2D();
        }
        else
        {
            camera_Change.GoTo3D();
        }
    }
}
