using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBool : Button_3D {

    public bool isClicked;

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }



    void OnStart()
    {
        isClicked = true;
    }
}
