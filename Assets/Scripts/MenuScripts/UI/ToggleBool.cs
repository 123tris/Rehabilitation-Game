using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBool : Button_3D {

    public bool isClickedToggle;

    void Start()
    {
        buttonPressed.AddListener(BoolToggle);
    }

    void BoolToggle()
    {
        isClickedToggle = true;
    }
}
